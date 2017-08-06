using Sentient.Resources.Interfaces;
using System;

namespace Sentient
{
    class Program {
        static void Main(string[] args) {
            System.Diagnostics.Trace.WriteLine(Resources.Constants.Trace.Initialize);
            Console.WriteLine("Starting up Sentient V1.0.");

            Factory.Instance.LoadAssemblies();
            Factory.Instance.CreateProcessors();
            Factory.Instance.CreateInternalReceivers();

            ICore core = Factory.Instance.CreateCore();

            core.Start();

            Console.WriteLine("Sentient terminated.");
            Console.ReadLine();

            System.Diagnostics.Trace.WriteLine(Resources.Constants.Trace.Date);
        }
    }
}
