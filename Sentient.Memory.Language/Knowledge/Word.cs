//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sentient.Memory.Language.Knowledge
{
    using System;
    using System.Collections.Generic;
    
    public abstract partial class Word
    {
        public long WordID { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public string EmotionalCharge { get; set; }
        public string Family { get; set; }
        public Nullable<bool> Masculin { get; set; }
        public Nullable<bool> Singular { get; set; }
    }
}