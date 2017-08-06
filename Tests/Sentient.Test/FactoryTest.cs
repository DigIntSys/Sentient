using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;
using System.Linq;
using Sentient.Resources.Interfaces.Node.Internal;
using System.Collections.Generic;
using Sentient.Resources.Interfaces.Node;

namespace Sentient.Test
{
    [TestClass]
    public class FactoryTest
    {

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }

        public FactoryTest()
        {
            Factory.Instance.LoadAssemblies();

        }

        [TestMethod]
        public void Factory_CreateReceivers()
        {
            Factory.Instance.CreateInternalReceivers();
            //TODO: Test the core initialization properly
            string[] assemblyNames = File.ReadAllLines($"{AssemblyDirectory}\\Resources\\internalReceivers.txt");
            var fullAssemblyname = new List<string>();

            for (int i = 0; i < assemblyNames.Count(); i++)
            {
                fullAssemblyname.Add(string.Concat(assemblyNames[i], ".Internal.Receiver"));
            }

            IEnumerable<IReceiver> receivers = Pool.Internal.Receivers.Instance.List.FindAll(r => fullAssemblyname.Contains(r.ToString()));
            Assert.AreEqual(assemblyNames.Count(), receivers.Count());
        }

        [TestMethod]
        public void Factory_CreateProcessors()
        {
            Factory.Instance.CreateProcessors();

            //TODO: Test the core initialization properly
            string[] assemblyNames = File.ReadAllLines($"{AssemblyDirectory}\\Resources\\processors.txt");
            var fullAssemblyname = new List<string>();

            for (int i = 0; i < assemblyNames.Count(); i++)
            {
                fullAssemblyname.Add(string.Concat(assemblyNames[i], ".Processor"));
            }

            IEnumerable<IProcessor> receivers = Pool.Processors.Instance.List.FindAll(r => fullAssemblyname.Contains(r.ToString()));

            Assert.AreEqual(assemblyNames.Count(), receivers.Count());
        }

    }
}
