//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LolFightProjekat.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Admin
    {
        public Admin()
        {
            this.AdminMails = new HashSet<AdminMail>();
        }
    
        public int IdAdmin { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string eMail { get; set; }
        public string ImageUrl { get; set; }
    
        public virtual ICollection<AdminMail> AdminMails { get; set; }
    }
}
