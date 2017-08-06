using Sentient.Resources.Abstracts;
using Sentient.Signals;
using Sentient.Signals.Enums;
using System.Threading.Tasks;

namespace Sentient.Perception.Console.Internal
{
    internal class Transmitter : ATransmitter
    {
        public override void SendSignal(Impulse impulse)
        {
            if (impulse != null)
            {
                impulse.Node = Node.Perception;
                Parallel.ForEach(Pool.Internal.Receivers.Instance.List, receiver => receiver.ReceiveSignal(impulse));
            }

        }
    }
}
