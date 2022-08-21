using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIK_Knjizara.Models.ViewModels
{
    public class UpdateUserModel : User
    {
        public UpdateUserModel()
        {
        }

        public UpdateUserModel(User user)
        {
            IdUser = user.IdUser;
            PersonCode = user.PersonCode;
            FName = user.FirstName;
            LName = user.LastName;
            E_mail = user.Email;
            Password = user.Password;
            City = user.City;
            ZipCode = user.ZipCode;
            StreetName = user.StreetName;
            StreetNumber = user.StreetNumber;
        }

        [Required(ErrorMessage = "First name is a must")]
        [Display (Name = "First name")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last name is a must")]
        [Display (Name = "Last name")]
        public string LName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is a must")]
        [Display (Name = "Email")]
        public string E_mail { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Old password")]
        public string OldPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

    }
}