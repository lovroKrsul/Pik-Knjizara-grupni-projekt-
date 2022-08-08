using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PIK_Library.Model
{
    public class User
    {
        public int IdUser { get; set; }
        public string PersonCode { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string City { get; set; }

        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }

        [Display(Name = "Street name")]
        public string StreetName { get; set; }

        [Display(Name = "Street number")]
        public string StreetNumber { get; set; }

        public string OIB { get; set; }

        public string Workplace { get; set; }

        public override string ToString() => $"{FirstName} {LastName}";
    }
}
