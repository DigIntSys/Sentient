namespace Sentient.Signals.Impulses
{
    public class Data : Impulse
    {
        public string Content { get; set; }

        public Data()
        {

        }

        public Data(Data data)
        {
            this.Content = data.Content;
        }
    }
}
