using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentient.Memory.Language;
using Sentient.Memory.Language.Internal;
using Sentient.Resources.Interfaces.Node;

namespace Sentient.Test.Memory
{
    [TestClass]
    public class ProcessorTest
    {
        public ProcessorTest()
        {
            //
            // TODO: Add constructor logic here
            //
            Factory.Instance.LoadAssemblies();
            Factory.Instance.CreateProcessors();
        }

        [TestMethod]
        public void Stop_Memory()
        {
            IProcessor logicProcessor = Pool.Processors.Instance.List.Find(p => p is Processor);
            logicProcessor.Stop();

            Assert.IsNull(Pool.Internal.Receivers.Instance.List.Find(r => r is Receiver));

        }
    }
}
