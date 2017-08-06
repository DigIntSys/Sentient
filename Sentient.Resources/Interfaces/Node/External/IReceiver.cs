using Sentient.Signals;

namespace Sentient.Resources.Interfaces.Node.External
{
    public interface IReceiver
    {
        Impulse ReceiveSignal();

    }
}
