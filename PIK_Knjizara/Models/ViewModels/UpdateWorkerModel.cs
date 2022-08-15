﻿using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIK_Knjizara.Models.ViewModels
{
    public class UpdateWorkerModel : User
    {
        public UpdateWorkerModel()
        {
        }

        public UpdateWorkerModel(User user)
        {
            IdUser = user.IdUser;
            PersonCode = user.PersonCode;
            FName = user.FirstName;
            LName = user.LastName;
            E_mail = user.Email;
            Password = user.Password;
            OIB = user.OIB;
            Workplace = user.Workplace;
        }

        [Required(ErrorMessage = "First name is a must")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last name is a must")]
        public string LName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is a must")]
        public string E_mail { get; set; }

        //[Compare("Password", ErrorMessage = "Passwords must match")]
        [DataType(DataType.Password)]
        [Display(Name = "Old password")]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }
    }
}