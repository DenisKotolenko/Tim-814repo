//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WCFService.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ranking
    {
        public int IdRanking { get; set; }
        public Nullable<int> FarmGold { get; set; }
        public Nullable<int> StolenGold { get; set; }
    
        public virtual Champion Champion { get; set; }
    }
}
