using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentient.Logic.Language;
using Sentient.Logic.Language.Internal;
using Sentient.Resources.Interfaces.Node;

namespace Sentient.Test.Logic
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
        public void Stop_Logic()
        {

            IProcessor logicProcessor = Pool.Processors.Instance.List.Find(p => p is Processor);
            logicProcessor.Stop();

            Assert.IsNull(Pool.Internal.Receivers.Instance.List.Find(r => r is Receiver));
        }
    }
}
