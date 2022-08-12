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
        public string Title { get; set; }
        [Required]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Cover { get; set; }
    }
}