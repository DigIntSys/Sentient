using Sentient.Resources.Interfaces.Node;
using System;
using System.Collections.Generic;

namespace Sentient.Pool
{
    public sealed class Processors
    {
        public List<IProcessor> List { get; set; }

        private static Processors instance = null;

        private static readonly object padlock = new Object();

        Processors()
        {
            this.List = new List<IProcessor>();
        }

        public static Processors Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Processors();
                    }
                    return instance;
                }
            }
        }
    }


}