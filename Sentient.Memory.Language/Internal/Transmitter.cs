using Sentient.Resources.Abstracts;
using Sentient.Signals;
using System.Threading.Tasks;
using Sentient.Signals.Enums;

namespace Sentient.Memory.Language.Internal
{
    internal class Transmitter : ATransmitter
    {
        public override void SendSignal(Impulse impulse)
        {
            if (impulse != null)
            {
                impulse.Node = Node.Memory;
                Parallel.ForEach(Pool.Internal.Receivers.Instance.List, receiver => receiver.ReceiveSignal(impulse));
            }
        }
    }
}

