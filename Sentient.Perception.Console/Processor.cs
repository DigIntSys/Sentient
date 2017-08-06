using Sentient.Perception.Console.External;
using Sentient.Perception.Console.Internal;
using Sentient.Resources;
using Sentient.Signals;
using Sentient.Signals.Enums;
using Sentient.Signals.Impulses;

namespace Sentient.Perception.Console
{
    public class Processor : AProcessor
    {
        private bool IsActive = true;

        private Receiver Receiver;

        public Processor()
        {
            Receiver = new Receiver();
            Transmitter = new Transmitter();
        }


        public override void Process(Impulse impulse)
        {
            //TODO: Perception has to chew up raw data and see what to do with it. Since it te      xt communication, it can only be words, so it should start with memory.
            if (impulse is Data)
            {
                if ((impulse as Data).Content.ToLowerInvariant().StartsWith("bye!"))
                {
                    impulse.Signal = SignalType.Terminate;
                    impulse.Outcome = Outcome.Success;

                    Transmitter.SendSignal(impulse);

                    Stop();
                    return;
                }
                else
                {
                    impulse.Signal = SignalType.Receive;
                    impulse.Outcome = Outcome.Success;
                }
            }

            Transmitter.SendSignal(impulse);
            System.Diagnostics.Trace.WriteLine(string.Format("{0};{1};{2}", Resources.Constants.Trace.Date, this.ToString(), impulse.Signal, impulse.Outcome));
        }

        public override void Run()
        {
            System.Diagnostics.Trace.WriteLine(string.Format("{0};{1};{2}", Resources.Constants.Trace.Date, this.ToString(), NodeStatus.Start));

            do
            {
                Impulse impulse = Receiver.ReceiveSignal();
                Process(impulse);

            } while (IsActive);

            System.Diagnostics.Trace.WriteLine(string.Format("{0};{1};{2}", Resources.Constants.Trace.Date, this.ToString(), NodeStatus.Stop));
        }

        public override void Stop()
        {
            IsActive = false;
        }
    }
}
