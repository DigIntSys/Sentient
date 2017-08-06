using Sentient.Resources.Interfaces;
using Sentient.Resources.Interfaces.Node;
using Sentient.Resources.Interfaces.Node.Internal;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Sentient
{
    internal sealed class Factory : IFactory
    {

        private static Factory instance = null;

        private static readonly object padlock = new Object();

        Factory()
        {
        }

        public static Factory Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Factory();
                    }
                    return instance;
                }
            }
        }

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

        public void LoadAssemblies()
        {
            string[] assemblyNames = File.ReadAllLines($"{AssemblyDirectory}\\Resources\\assemblies.txt");

            foreach (var assembly in assemblyNames)
            {
                Assembly nodeAssembly = Assembly.Load(assembly);
            }

        }

        public ICore CreateCore()
        {
            Core core = new Core();
            return core;
        }

        public void CreateProcessors()
        {
            string[] assemblyNames = File.ReadAllLines($"{AssemblyDirectory}\\Resources\\processors.txt");

            foreach (var assemblyName in assemblyNames)
            {
                Assembly nodeAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(ass => ass.GetName().Name == assemblyName).FirstOrDefault();
                Type type = nodeAssembly.GetType($"{assemblyName}.Processor");
                dynamic dynamicProcessor = Activator.CreateInstance(type);
                IProcessor processor = (IProcessor)dynamicProcessor;
                Pool.Processors.Instance.List.Add(processor);
            }

        }

        public void CreateInternalReceivers()
        {
            string[] assemblyNames = File.ReadAllLines($"{AssemblyDirectory}\\Resources\\internalReceivers.txt");

            foreach (var assemblyName in assemblyNames)
            {
                Assembly nodeAssembly = AppDomain.CurrentDomain.GetAssemblies().Where(ass => ass.GetName().Name == assemblyName).FirstOrDefault();

                Type processorType = nodeAssembly.GetType($"{assemblyName}.Processor");
                IProcessor processor = Pool.Processors.Instance.List.Find(p => p.GetType() == processorType);

                Type type = nodeAssembly.GetType($"{assemblyName}.Internal.Receiver");
                dynamic dynamicReceiver = Activator.CreateInstance(type, processor);
                IReceiver receiver = (IReceiver)dynamicReceiver;

                Pool.Internal.Receivers.Instance.List.Add(receiver);
            }
        }

    }
}
