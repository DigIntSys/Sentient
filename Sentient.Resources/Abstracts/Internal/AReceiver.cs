using Sentient.Resources.Interfaces.Node;
using Sentient.Resources.Interfaces.Node.Internal;
using Sentient.Signals;

namespace Sentient.Resources.Internal
{
    public abstract class AReceiver : IReceiver
    {
        public AProcessor Processor { get; set; }

        public AReceiver(IProcessor processor)
        {
            this.Processor = processor as AProcessor;
        }

        /// <summary>
        /// Method that will receive raw signal from an internal source
        /// </summary>
        /// <returns></returns>
        public abstract void ReceiveSignal(Impulse impulse);

    }
}
