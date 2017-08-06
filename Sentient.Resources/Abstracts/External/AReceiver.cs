using Sentient.Resources.Interfaces.Node.External;
using Sentient.Signals;

namespace Sentient.Resources.External
{
    public abstract class AReceiver : IReceiver
    {
        /// <summary>
        /// Method that will receive raw signals from an outside source
        /// </summary>
        /// <returns></returns>
        public abstract Impulse ReceiveSignal();
    }
}
