using Sentient.Signals.Enums;

namespace Sentient.Signals
{
    /// <summary>
    /// The main signal being transmitted. This class is extended by all other signals.
    /// </summary>
    public class Impulse
    {
        public Node Node { get; set; }
        public SignalType Signal { get; set; }
        public Outcome Outcome { get; set; }

    }
}
