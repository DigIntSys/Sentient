using Newtonsoft.Json;

namespace Sentient.Information.Language.Signal
{
    public class Definition
    {
        public DefinitionMetadata Metadata { get; set; }
        public DefinitionResult[] Results { get; set; }
    }

    [JsonObject(Title = "Metadata")]
    public class DefinitionMetadata
    {
        public string Provider { get; set; }
    }

    [JsonObject(Title = "Result")]
    public class DefinitionResult
    {
        public string Id { get; set; }
        public string Language { get; set; }
        public Lexicalentry[] LexicalEntries { get; set; }
        public string Type { get; set; }
        public string Word { get; set; }
    }

    public class Lexicalentry
    {
        public Entry[] Entries { get; set; }
        public string Language { get; set; }
        public string LexicalCategory { get; set; }
        public Pronunciation[] Pronunciations { get; set; }
        public string Text { get; set; }
    }

    public class Entry
    {
        public string[] Etymologies { get; set; }
        public Grammaticalfeature[] GrammaticalFeatures { get; set; }
        public string HomographNumber { get; set; }
        public Senses[] Senses { get; set; }
    }

    public class Grammaticalfeature
    {
        public string Text { get; set; }
        public string Type { get; set; }
    }

    public class Senses
    {
        public string[] Definitions { get; set; }
        public string[] Domains { get; set; }
        public Example[] Examples { get; set; }
        public string Id { get; set; }
        public string[] Registers { get; set; }
        public Subsenses[] Subsenses { get; set; }
        public string[] Regions { get; set; }
    }

    public class Example
    {
        public string[] Registers { get; set; }
        public string Text { get; set; }
    }

    public class Subsenses
    {
        public string[] Definitions { get; set; }
        public string[] Domains { get; set; }
        public Example1[] Examples { get; set; }
        public string Id { get; set; }
        public string[] Registers { get; set; }
        public Note[] Notes { get; set; }
    }

    public class Example1
    {
        public string text { get; set; }
    }

    public class Note
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Pronunciation
    {
        public string audioFile { get; set; }
        public string[] dialects { get; set; }
        public string phoneticNotation { get; set; }
        public string phoneticSpelling { get; set; }
    }

}

