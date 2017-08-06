namespace Sentient.Signals.Impulses.Language

{
    public class Word : Impulse
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public Word()
        {

        }

        public Word(Word word)
        {
            this.Name = word.Name;
            this.Type = word.Type;
            this.Description = word.Description;
        }

    }
}
