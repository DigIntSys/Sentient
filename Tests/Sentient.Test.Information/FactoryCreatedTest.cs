using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sentient.Information.Language;
using Sentient.Information.Language.Internal;
using Sentient.Resources.Interfaces.Node;
using Sentient.Resources.Interfaces.Node.Internal;
using System;
using System.Linq;
using System.Reflection;

namespace Sentient.Test.Information
{
    [TestClass]
    public class FactoryCreatedTest
    {

        [TestMethod]
        public void information_addedToAssembly()
        {
            Factory.Instance.LoadAssemblies();
            Assembly nodeAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(ass => ass.GetName().Name == "Sentient.Information.Language").FirstOrDefault();

            Assert.IsNotNull(nodeAssembly);

        }

        [TestMethod]
        public void information_addedToProcesorPool()
        {
            Factory.Instance.CreateProcessors();
            IProcessor processor = Pool.Processors.Instance.List.Find(p => p is Processor);

            Assert.IsNotNull(processor);
        }

        [TestMethod]
        public void information_addedToReceiversPool()
        {
            Factory.Instance.CreateInternalReceivers();

            IReceiver receiver = Pool.Internal.Receivers.Instance.List.Find(p => p is Receiver);

            Assert.IsNotNull(receiver);

        }
    }
}
