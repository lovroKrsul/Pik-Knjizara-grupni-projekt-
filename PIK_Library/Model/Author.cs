using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PIK_Library.Model
{
    public class Author
    {
        [Display(Name = "ID:")]
        [Required]
        public string ID { get; set; }
        [Display(Name = "Ime:")]
        [Required(ErrorMessage = "* Ovo je obvezno polje")]
        public string FirstName { get; set; }
        [Display(Name = "Prezime:")]
        [Required(ErrorMessage = "* Ovo je obvezno polje")]
        public string LastName { get; set; }
        [Display(Name = "Biografija:")]
        [Required(ErrorMessage = "* Ovo je obvezno polje")]
        public string Biography { get; set; }
        [Display(Name = "Opis:")]
        [Required(ErrorMessage = "* Ovo je obvezno polje")]
        public string Description { get; set; }
      

    }
   
}
