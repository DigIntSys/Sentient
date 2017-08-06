using Sentient.Signals;

namespace Sentient.Resources.Interfaces.Node
{
    /// <summary>
    /// The processor is the processing unit of each node.
    /// It handles the information that is coming from internal or external.
    /// Gets The stimulus that is coming from the receiver, processes and converts it into the data
    /// that is going to be sent to the other nodes.
    /// </summary>
    public interface IProcessor
    {
        void Run();
        void Stop();
        void Process(Impulse stimulus);

    }
}
