using Sentient.Resources.Interfaces.Node.Internal;
using System;
using System.Collections.Generic;

namespace Sentient.Pool.Internal
{
    public sealed class Receivers
    {
        public List<IReceiver> List { get; set; }

        private static Receivers instance = null;

        private static readonly object padlock = new Object();

        Receivers()
        {
            this.List = new List<IReceiver>();
        }

        public static Receivers Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Receivers();
                    }
                    return instance;
                }
            }
        }
    }


}
