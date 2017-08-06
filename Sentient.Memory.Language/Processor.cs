using Sentient.Memory.Language.Helpers;
using Sentient.Memory.Language.Internal;
using Entity = Sentient.Memory.Language.Knowledge;
using Sentient.Resources;
using Sentient.Signals;
using Sentient.Signals.Enums;
using Sentient.Signals.Impulses;
using Sentient.Signals.Impulses.Language;
using System.Linq;


namespace Sentient.Memory.Language
{
    public class Processor : AProcessor
    {
        public Processor()
        {
            Transmitter = new Transmitter();
        }

        public override void Process(Impulse impulse)
        {
            Impulse response = null;

            switch (impulse.Signal)
            {
                case SignalType.Receive:
                    // Information is being received from perception. Lets see if I know what it means.
                    if (impulse is Data)
                    {
                        var query = impulse as Data;

                        Entity.Word dbWord = RepositoryManager.Language.GetWordByName(query.Content).FirstOrDefault();
                        if (dbWord != null)
                        {
                            // I know what it means.
                            response = Map.EntityToSignal(dbWord);
                            response.Signal = SignalType.Response;
                            response.Outcome = Outcome.Success;
                        }
                        else
                        {
                            // Don't know what it means.
                            response = new Data(impulse as Data);
                            response.Signal = SignalType.Response;
                            response.Outcome = Outcome.Failure;
                        }
                    }
                    break;
                case SignalType.Request:
                    //TODO: Logic requests a word from memory.
                    break;
                case SignalType.Response:
                    // A response is coming from logic. Lets memorize it.
                    if (impulse.Outcome == Outcome.Success)
                    {
                        if (impulse is Word)
                        {
                            Entity.Word dbWord = Map.SignalToEntity(impulse as Word);

                            if (dbWord == null)
                            {
                                System.Diagnostics.Trace.WriteLine($"{Resources.Constants.Trace.Date};{this.ToString()};{Resources.Constants.Trace.AddWord};{Outcome.Failure.ToString()};{Resources.Constants.Trace.NoWordType}");
                            }
                            else
                            {
                                int wordId = RepositoryManager.Language.AddWord(dbWord);
                                if (wordId == 0)
                                    System.Diagnostics.Trace.WriteLine(string.Format("{0};{1};{2};{3};{4}", Resources.Constants.Trace.Date, this.ToString(), Resources.Constants.Trace.AddWord, Outcome.Failure.ToString(), wordId));
                                else
                                    System.Diagnostics.Trace.WriteLine(string.Format("{0};{1};{2};{3};{4}", Resources.Constants.Trace.Date, this.ToString(), Resources.Constants.Trace.AddWord, Outcome.Success.ToString(), wordId));
                            }
                        }
                    }
                    break;

                default:
                    System.Diagnostics.Trace.WriteLine(string.Format("{0};{1};{2}", Resources.Constants.Trace.Date, this.ToString(), Resources.Constants.Trace.Default));
                    return;
            }

            if (response != null)
            {
                Transmitter.SendSignal(response);
                System.Diagnostics.Trace.WriteLine(string.Format("{0};{1};{2}", Resources.Constants.Trace.Date, this.ToString(), response.Signal));
            }

        }
        public override void Stop()
        {
            DataPool.Dispose();
            DataPool = null;

            Pool.Internal.Receivers.Instance.List.RemoveAll(r => r is Receiver);

        }
    }
}
