using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIK_Library.Model
{
    public class ContactUs
    {
        public int IdContact { get; set; }
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
        public bool Viewed { get; set; }
    }
}