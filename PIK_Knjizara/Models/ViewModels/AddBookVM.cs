using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIK_Knjizara.Models.ViewModels
{
    public class AddBookVM : Book
    {
        [Required]
        [Display(Name = "Title")]
        public string Titl { get; set; }
        [Required]
        public int Author_Id { get; set; }
        public IList<Author> Authors { get; set; }
        [Required]
        [Display(Name = "ISBN")]
        public string ibsn { get; set; }
        [Required]
        [Display(Name = "Price")]
        public decimal Pric { get; set; }
    }
}