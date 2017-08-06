using Newtonsoft.Json;

namespace Sentient.Information.Language.Signal
{
    internal class Lemma
    {
        public LemmaMetadata Metadata { get; set; }
        public LemmaResult[] Results { get; set; }
    }

    [JsonObject(Title = "Metadata")]
    public class LemmaMetadata
    {
        public string Provider { get; set; }
    }

    [JsonObject(Title = "Result")]
    public class LemmaResult
    {
        public string Id { get; set; }
        public string Language { get; set; }
        public LexicalEntry[] LexicalEntries { get; set; }
        public string Word { get; set; }
    }

    public class LexicalEntry
    {
        public GrammaticalFeature[] GrammaticalFeatures { get; set; }
        public InflectionOf[] InflectionOf { get; set; }
        public string Language { get; set; }
        public string LexicalCategory { get; set; }
        public string Text { get; set; }
    }

    public class GrammaticalFeature
    {
        public string Text { get; set; }
        public string Type { get; set; }
    }

    public class InflectionOf
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}


