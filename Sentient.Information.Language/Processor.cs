using Sentient.Information.Language.External;
using Sentient.Information.Language.Helpers;
using Sentient.Information.Language.Internal;
using Sentient.Information.Language.Signal;
using Sentient.Resources;
using Sentient.Resources.Abstracts.External;
using Sentient.Signals;
using Sentient.Signals.Impulses;
using System.Diagnostics;
using Sentient.Signals.Enums;

namespace Sentient.Information.Language
{
    public class Processor : AProcessor
    {
        public ACollector Collector { get; set; }
        public Processor()
        {
            Collector = new Collector();
            Transmitter = new Transmitter();
        }

        public override void Process(Impulse impulse)
        {
            Impulse result = null;

            if (impulse is Data)
            {
                //TODO: new to chew up the data before i decide what to do with it.
                //  i will only check for a definition if that is what the query requests.
                Data query = impulse as Data;
                Parameters parameters = ParameterGenerator.GenerateParameters(query.Content, "/api/v1/entries/en/");
                Definition definition = Collector.GatherData<Definition>(parameters).Result as Definition;

                if (definition != null)
                {
                    result = Map.DefinitionToWord(definition);

                    if (result != null)
                    {
                        result.Outcome = Outcome.Success;
                        result.Signal = SignalType.Response;
                    }
                    else
                    {
                        Trace.WriteLine($"{Resources.Constants.Trace.Date};{this.ToString()};{SignalType.None};{Outcome.Failure}");
                    }
                }
                else
                {
                    result = new Data
                    {
                        Content = "",
                        Outcome = Outcome.Failure,
                        Signal = SignalType.Response,
                    };
                }

                if (result != null)
                {
                    Transmitter.SendSignal(result);
                    Trace.WriteLine(string.Format("{0};{1};{2}", Resources.Constants.Trace.Date, this.ToString(), result.Signal));
                }
            }

        }
        public override void Stop()
        {
            DataPool.Dispose();
            DataPool = null;

            Pool.Internal.Receivers.Instance.List.RemoveAll(receiver => receiver is Receiver);

        }
    }

}
