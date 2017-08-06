using Sentient.Signals;

namespace Sentient.Resources.Interfaces.Node.Internal
{
    public interface IReceiver
    {
        void ReceiveSignal(Impulse impulse);
    }
}
