using Sentient.Resources.Abstracts;
using Sentient.Signals;
using System.Threading.Tasks;
using Sentient.Signals.Enums;

namespace Sentient.Logic.Language.Internal
{
    internal class Transmitter : ATransmitter
    {
        public override void SendSignal(Impulse impulse)
        {
            if (impulse != null)
            {
                impulse.Node = Node.Logic;
                Parallel.ForEach(Pool.Internal.Receivers.Instance.List, receiver => receiver.ReceiveSignal(impulse));
            }
        }
    }
}
