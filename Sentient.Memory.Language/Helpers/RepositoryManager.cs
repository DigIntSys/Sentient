using SR = Sentient.Memory.Language.Knowledge.Repositories;

namespace Sentient.Memory.Language.Helpers
{
    internal class RepositoryManager
    {
        public static SR.Language Language
        {
            get
            {
                return new SR.Language();
            }
        }

    }

}

