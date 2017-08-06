using Sentient.Resources.Abstracts;
using Sentient.Resources.Interfaces.Node;
using Sentient.Signals;
using System;
using System.Collections.Concurrent;
using Sentient.Signals.Enums;
using System.Diagnostics;

namespace Sentient.Resources
{
    public abstract class AProcessor : IProcessor
    {
        public ATransmitter Transmitter { get; set; }
        public BlockingCollection<Impulse> DataPool { get; set; }

        public AProcessor()
        {
            DataPool = new BlockingCollection<Impulse>();
        }

        public virtual void Run()
        {
            System.Diagnostics.Trace.WriteLine(string.Format("{0};{1};{2}", Constants.Trace.Date, this.ToString(), NodeStatus.Start));

            while (!DataPool.IsCompleted)
            {
                try
                {
                    Impulse newStimulus = DataPool.Take();
                    Process(newStimulus);
                }
                catch (InvalidOperationException ex)
                {
                    // exception is thrown when the IsCompleted signal is sent
                    // TODO: Find a better way to terminate the processor
                    Trace.WriteLine($"{Constants.Trace.Date};{this.ToString()};{ex}");
                    break;
                }
            }

            Stop();

            Trace.WriteLine(string.Format("{0};{1};{2}", Constants.Trace.Date, this.ToString(), NodeStatus.Stop));
        }

        public abstract void Stop();

        public abstract void Process(Impulse stimulus);
    }
}
