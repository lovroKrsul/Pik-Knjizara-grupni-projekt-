using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIK_Knjizara.Models.ViewModels
{
    public class PasswordResetVM : User
    {
        [Display(Name = "Email")]
        [EmailAddress]
        [Required(ErrorMessage = "Email is a must")]
        public string E_mail { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Passwords is a must")]
        [DataType(DataType.Password)]
        public string Pass { get; set; }

        [Required(ErrorMessage = "Must confirm password")]
        [Compare("Pass", ErrorMessage = "Passwords must match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}