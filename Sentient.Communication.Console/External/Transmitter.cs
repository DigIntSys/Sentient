using Sentient.Resources.Abstracts;
using Sentient.Signals;
using Sentient.Signals.Impulses;
using System.Collections.Generic;
using System.Linq;

namespace Sentient.Communication.Console.External
{
    internal class Transmitter : ATransmitter
    {

        public override void SendSignal(Impulse impulse)
        {
            List<string> dataList = null;
            if(impulse is Data)
            {
                    dataList = (impulse as Data).Content.Split('|').ToList();
            }

            if(dataList != null)
            {
                dataList.ForEach(d => System.Console.WriteLine(d));
            }
        }

    }
}
