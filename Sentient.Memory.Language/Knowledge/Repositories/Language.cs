using System.Linq;

namespace Sentient.Memory.Language.Knowledge.Repositories
{
    internal class Language : BaseRepository
    {


        public IQueryable<Word> GetWordByName(string wordName)
        {
            return Context.Set<Word>().Where(w => w.Name == wordName);
        }

        public int AddWord(Word word)
        {
            Context.Words.Add(word);
            return SaveChanges();
        }

        public IQueryable<Word> GetWords()
        {
            return Context.Set<Word>();
        }

    }
}
