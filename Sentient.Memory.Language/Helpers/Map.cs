using Sentient.Memory.Language.Knowledge;
using SL = Sentient.Signals.Impulses.Language;

namespace Sentient.Memory.Language.Helpers
{
    internal static class Map
    {
        public static Word SignalToEntity(SL.Word impulse)
        {
            Word word = null;
            if(typeof(Noun).Name.ToLowerInvariant() == impulse.Type.ToLowerInvariant())
            {
                word = new Noun
                {
                    Name = impulse.Name,
                    Definition = impulse.Description,
                };
            }

            if(typeof(Adjective).Name.ToLowerInvariant() == impulse.Type.ToLowerInvariant())
            {
                word = new Adjective
                {
                    Name = impulse.Name,
                    Definition = impulse.Description,
                };
            }

            if(typeof(Verb).Name.ToLowerInvariant() == impulse.Type.ToLowerInvariant())
            {
                word = new Verb
                {
                    Name = impulse.Name,
                    Definition = impulse.Description,
                };
            }

            return word;
        }

        internal static SL.Word EntityToSignal(Word dbWord)
        {
            return new SL.Word
            {
                Name = dbWord.Name,
                Description = dbWord.Definition,
                Type = dbWord.GetType().Name,
            };
        }

    }
}
