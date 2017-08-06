using Sentient.Resources.Interfaces;
using System.Threading.Tasks;

namespace Sentient
{
    public class Core : ICore
    {

        public Core()
        {
        }

        public void Start()
        {
            Parallel.ForEach(Pool.Processors.Instance.List, np => np.Run());
        }

        public void Stop()
        {

            Pool.Processors.Instance.List.Clear();
            //TODO: this can be the master kill switch.
            // right now Setient is being terminated with console input, after all processors finish their task.
        }

    }
}
