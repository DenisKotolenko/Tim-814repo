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
    
    public partial class Mail
    {
        public int IdMail { get; set; }
        public int IdSender { get; set; }
        public int IdReceiver { get; set; }
        public Nullable<int> Time { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
    
        public virtual Champion Champion { get; set; }
        public virtual Champion Champion1 { get; set; }
    }
}
