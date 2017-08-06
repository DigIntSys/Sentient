using Sentient.Information.Language.Signal;
using Sentient.Signals.Impulses.Language;
using System.Linq;

namespace Sentient.Information.Language.Helpers
{
    internal static class Map
    {
        internal static Word DefinitionToWord(Definition definition)
        {
            return new Word
            {
                Name = definition.Results.First().Word,
                Type = definition.Results.First().LexicalEntries.First().LexicalCategory,
                Description = definition.Results.First().LexicalEntries.First().Entries.First().Senses.First().Definitions.First(),
                
            };
        }

    }
}
