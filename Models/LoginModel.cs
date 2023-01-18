using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FFFWebApplication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter user name.")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User Name")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}