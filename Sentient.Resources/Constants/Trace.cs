using System;

namespace Sentient.Resources.Constants
{
    public static class Trace
    {
        public static readonly string Date = DateTime.Now.ToString("dd-MM-yy HH:mm ss");
        public static readonly string Initialize = "Date;Assembly;Signal;Aditional info";
        
        public static readonly string Default = "Default Hit";
        public static readonly string NoWordType = "Word Type not found";
        public static readonly string None = "None";

        // Memory Constants
        public static readonly string AddWord = "Add Word";
        public static readonly string GetWord = "Add Word";
    }
}
