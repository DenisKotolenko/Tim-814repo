using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
//using System.Web.Mvc;


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

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Just repeat the damn password.")]
        public string ConfirmPassword { get; set; }
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$",
        ErrorMessage = "..that doesn't seem right.")]
        public string eMail { get; set; }
    }
}