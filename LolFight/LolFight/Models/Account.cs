using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LolFight.Models
{
    public class Account
    {
        public int IdUser { get; set; }
        [Required(ErrorMessage = "You know you need a username right?", AllowEmptyStrings = false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "You need a password, make it strong!", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        [StringLength(50, MinimumLength = 9, ErrorMessage = "Let's make it at least 9 characters, to be safe..")]
        public string Password { get; set; }
        //[Compare("Password", ErrorMessage = "Confirm password dose not match.")]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string ConfirmPassword { get; set; }
        public string eMail { get; set; }
    }
}