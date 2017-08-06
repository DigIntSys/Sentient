using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentient.Information.Language;
using Sentient.Information.Language.Internal;
using Sentient.Resources.Interfaces.Node;

namespace Sentient.Test.Information
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
        public void Stop_information()
        {

            IProcessor logicProcessor = Pool.Processors.Instance.List.Find(p => p is Processor);
            logicProcessor.Stop();

            Assert.IsNull(Pool.Internal.Receivers.Instance.List.Find(r => r is Receiver));
        }

    }
}
