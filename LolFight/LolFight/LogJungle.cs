//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LolFight
{
    using System;
    using System.Collections.Generic;
    
    public partial class LogJungle
    {
        public int IdLogJungle { get; set; }
        public int IdChampion { get; set; }
        public Nullable<int> StartTime { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<int> Gold { get; set; }
        public string Report { get; set; }
    
        public virtual Champion Champion { get; set; }
    }
}
