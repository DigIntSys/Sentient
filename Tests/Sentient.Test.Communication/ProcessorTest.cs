using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentient.Communication.Console;
using Sentient.Communication.Console.Internal;
using Sentient.Resources.Interfaces.Node;

namespace Sentient.Test.Communication
{
    [TestClass]
    public class ProcessorTest
    {
        public ProcessorTest()
        {
            Factory.Instance.LoadAssemblies();
            Factory.Instance.CreateProcessors();
            Factory.Instance.CreateInternalReceivers();
        }

        [TestMethod]
        public void Stop_Communication()
        {
            IProcessor logicProcessor = Pool.Processors.Instance.List.Find(p => p is Processor);
            logicProcessor.Stop();  

            Assert.IsNull(Pool.Internal.Receivers.Instance.List.Find(r => r is Receiver));

        }
    }
}
