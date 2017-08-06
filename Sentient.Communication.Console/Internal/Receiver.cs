using Sentient.Resources.Interfaces.Node;
using Sentient.Resources.Internal;
using Sentient.Signals;
using Sentient.Signals.Enums;

namespace Sentient.Communication.Console.Internal
{
    public class Receiver : AReceiver
    {
        public Receiver(IProcessor processor) : base(processor) { }

        /// <summary>
        /// Method that will receive raw signal
        /// </summary>
        /// <returns></returns>
        public override void ReceiveSignal(Impulse impulse)
        {
            if (impulse == null)
            {
                return;
            }

            if (impulse.Signal == SignalType.Terminate)
            {
                Processor.DataPool.CompleteAdding();
                return;
            }

            if (impulse.Node == Node.Logic && impulse.Signal == SignalType.Transmit)
            {
                Processor.DataPool?.Add(impulse);
            }
        }

    }
}
