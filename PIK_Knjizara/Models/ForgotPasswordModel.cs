using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIK_Knjizara.Models.ViewModels
{
    public class ForgotPasswordModel
    {
        //private readonly IEmailSender _emailSender;

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}