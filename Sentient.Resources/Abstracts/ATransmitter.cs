using Sentient.Signals;

namespace Sentient.Resources.Abstracts
{
    public abstract class ATransmitter
    {
        public abstract void SendSignal(Impulse impulse);
    }
}
