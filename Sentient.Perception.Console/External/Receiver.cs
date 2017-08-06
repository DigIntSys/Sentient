using Sentient.Resources.External;
using Sentient.Signals;
using Sentient.Signals.Impulses;
using System;
using System.IO;

namespace Sentient.Perception.Console.External
{
    internal class Receiver : AReceiver
    {
        /// <summary>
        /// Method that will receive raw signal
        /// </summary>
        /// <returns></returns>
        public override Impulse ReceiveSignal()
        {
            var rawInput = ReadInput(System.Console.In);
            string treatedString = String.Format(rawInput).ToLower().Trim(' ');

            var impulse = new Data
            {
                Content = treatedString,
            };
            
            return impulse;
            
        }

        /// <summary>
        /// The TextReader may receive input from several other sources. Not necessarily console.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static string ReadInput(TextReader reader)
        {
            return reader.ReadLine();
        }
    }
}
