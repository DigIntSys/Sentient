using Sentient.Logic.Language.Internal;
using Sentient.Resources;
using Sentient.Signals;
using Sentient.Signals.Enums;
using Sentient.Signals.Impulses;
using Sentient.Signals.Impulses.Language;
using System.Diagnostics;

namespace Sentient.Logic.Language
{
    /// <summary>
    /// Here, Sentient will decide what to do. It is the conscious part of her.
    /// For now, she will decide to listen to perception and repeat it through communication.
    /// </summary>
    public class Processor : AProcessor
    {
        public Processor()
        {
            Transmitter = new Transmitter();
        }

        public override void Process(Impulse impulse)
        {
            Impulse result = null;
            switch (impulse.Signal)
            {
                case SignalType.Response:
                    // There is information coming from one of the nodes
                    switch (impulse.Node)
                    {
                        case Node.Information:
                            // Information couldn't find the meaning.
                            if (impulse.Outcome == Outcome.Failure)
                            {
                                result = new Data
                                {
                                    Content = "I do not know.",
                                    Outcome = Outcome.Failure,
                                    Signal = SignalType.Transmit,
                                };
                            }
                            else
                            {
                                // i know what you mean. lets memorize it.
                                result = new Word(impulse as Word);
                                result.Outcome = Outcome.Success;
                                result.Signal = SignalType.Response;
                            }
                            break;

                        case Node.Logic:
                            // logic calls upon itself recursively until it reaches a stop condition. That's how thinking is processed in the brain. We are calling upon a thought based
                            // on the response from a previous thought.
                            if (impulse is Word)
                            {
                                // i know this word. lets send it.
                                result = new Word(impulse as Word);
                                result.Outcome = Outcome.Success;
                                result.Signal = SignalType.Transmit;
                            }
                            break;
                        case Node.Memory:
                            if (impulse.Outcome == Outcome.Success)
                            {
                                // I know what it means. Lets send it.
                                //TODO: I might not want to send it. I might want to think about it... is there any history behind the word? what are the implications of the word?
                                result = new Word(impulse as Word);
                                result.Outcome = Outcome.Success;
                                result.Signal = SignalType.Transmit;
                            }
                            else
                            {
                                // Memory doesnt know what it means.
                                if (impulse is Data)
                                {
                                    // There is something that i don't know.
                                    // Lets see if I can find out what it means.
                                    result = new Data
                                    {
                                        Content = (impulse as Data).Content,
                                        Outcome = Outcome.Success,
                                        Signal = SignalType.Search
                                    };
                                }
                            }
                            break;
                        default:
                            break;
                    }
                    break;
                default:
                    Trace.WriteLine($"{Resources.Constants.Trace.Date};{this.ToString()};{impulse?.Signal.ToString() ?? Resources.Constants.Trace.None};{impulse?.Outcome.ToString() ?? Resources.Constants.Trace.None}");
                    return;
            }

            if (result != null)
            {
                Transmitter.SendSignal(result);
                Trace.WriteLine($"{Resources.Constants.Trace.Date};{this.ToString()};{result.Signal};{result.Outcome}");
            }
            else
            {
                Trace.WriteLine($"{Resources.Constants.Trace.Date};{this.ToString()};{SignalType.None};{Outcome.Failure};{NodeStatus.Exception}");
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
