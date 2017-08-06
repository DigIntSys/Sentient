using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentient.Memory.Language.Helpers;
using Sentient.Memory.Language.Knowledge;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sentient.Test.Memory.Knowledge
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void Memory_SaveAndGetWords()
        {

            var noun = new Noun()
            {
                Definition = "test",
                EmotionalCharge = "strong",
                Family = "TestFamily",
                Name = "TestNoun",
            };

            RepositoryManager.Language.AddWord(noun);

            var adjective = new Adjective()
            {
                Degree = "Inferior",
                Masculin = false,
                Singular = false,
                Definition = "TestDefinition",
                EmotionalCharge = "strong",
                Family = "beautiful",
                Name = "TestAdjective",
            };
            RepositoryManager.Language.AddWord(adjective);

            var verb = new Verb()
            {
                Definition = "testVerb",
                EmotionalCharge = "strong",
                Family = "TestFamily",
                Name = "TestVerb",
                Masculin = true,
                Participle = "past",
                Singular = true

            };
            RepositoryManager.Language.AddWord(verb);

            List<Word> words = RepositoryManager.Language.GetWords().ToList();
            IEnumerable<string> wordNames = words.Select(w => w.Name);
            Assert.IsTrue(wordNames.Contains(verb.Name) && wordNames.Contains(adjective.Name) && wordNames.Contains(noun.Name));

        }


        [TestMethod]
        public void Memory_SaveAndFetchSingleWord()
        {
            var noun = new Noun()
            {
                Definition = "testNoun",
                EmotionalCharge = "strong",
                Family = "TestFamily",
                Name = "TestNoun",
            };

            RepositoryManager.Language.AddWord(noun);

            Word word = RepositoryManager.Language.GetWordByName(noun.Name).FirstOrDefault();
            if(word == null)
                throw new Exception("Word not found");
            Noun result = word as Noun;

            Assert.IsNotNull(result);
        }

    }
}
