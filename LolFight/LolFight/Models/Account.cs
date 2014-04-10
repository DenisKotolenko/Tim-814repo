using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Recaptcha;
//using System.Web.Mvc;


namespace LolFight.Models
{
    public class Account
    {
        public int IdUser { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "NoName", AllowEmptyStrings = false)]
        public string Username { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "NoPassword", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 9, ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "ShortPassword")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "RepeatPassword")]
        public string ConfirmPassword { get; set; }
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "WeirdMail")]
        [Required(ErrorMessageResourceType = typeof(Resources.Resources), ErrorMessageResourceName = "NoMail", AllowEmptyStrings = false)]
        public string eMail { get; set; }
    }
}