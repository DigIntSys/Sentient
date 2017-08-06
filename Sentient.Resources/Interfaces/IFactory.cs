namespace Sentient.Resources.Interfaces
{
    public interface IFactory
    {
        ICore CreateCore();
        void CreateProcessors();
        void CreateInternalReceivers();
    }
}
