using Sentient.Communication.Console.External;
using Sentient.Communication.Console.Internal;
using Sentient.Resources;
using Sentient.Resources.Constants;
using Sentient.Signals;
using Sentient.Signals.Impulses;
using Sentient.Signals.Enums;
using Sentient.Signals.Impulses.Language;

namespace Sentient.Communication.Console
{
    public class Processor : AProcessor
    {
        public Processor()
        {
            Transmitter = new Transmitter();
        }

        public override void Process(Impulse impulse)
        {
            //TODO: Implement search on communication.
            // Logic may also ask for information directly instead of searching for it.
            Data result = null;
            if (impulse is Word)
            {
                var word = impulse as Word;
                result = new Data
                {
                    Content = $"{word.Type}|{word.Description}",
                    Outcome = Outcome.Success,
                    Signal = SignalType.Transmit,
                };
            }
            else if (impulse is Data)
            {
                result = impulse as Data;
            }
            else {
                System.Diagnostics.Trace.WriteLine(string.Format("{0};{1};{2};{3}", Trace.Date, this.ToString(), SignalType.None, Outcome.Failure));
                return;
            }

            Transmitter.SendSignal(result);
            System.Diagnostics.Trace.WriteLine(string.Format("{0};{1};{2};{3}", Trace.Date, this.ToString(), impulse.Signal, impulse.Outcome));
        }

        public override void Stop()
        {
            DataPool.Dispose();
            DataPool = null;

            Pool.Internal.Receivers.Instance.List.RemoveAll(r => r is Receiver);

        }
    }
}
