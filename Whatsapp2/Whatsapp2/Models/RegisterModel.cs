using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Whatsapp2.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Your Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Your Email is required!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Your Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Your Confirm Password is required!")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The Passwords need to match!")]
        public string ConfirmPassword { get; set; }
    }
}