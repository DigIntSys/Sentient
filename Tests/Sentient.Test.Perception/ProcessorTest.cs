using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentient.Perception.Console;
using Sentient.Resources.Interfaces.Node;

namespace Sentient.Test.Perception
{
    /// <summary>
    /// Summary description for ProcessorTest
    /// </summary>
    [TestClass]
    public class ProcessorTest
    {
        private IProcessor Perception;

        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            Factory.Instance.LoadAssemblies();
            Factory.Instance.CreateProcessors();
            Factory.Instance.CreateInternalReceivers();
        }

        [TestInitialize()]
        public void MyTestInitialize()
        {
            Perception = Pool.Processors.Instance.List.Find(p => p is Processor);
        }

    }
}
