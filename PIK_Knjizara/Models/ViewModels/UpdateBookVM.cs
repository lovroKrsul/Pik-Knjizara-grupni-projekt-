using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIK_Knjizara.Models.ViewModels
{
    public class UpdateBookVM : Book
    {
        public UpdateBookVM()
        {
        }

        public UpdateBookVM(Book book)
        {
            IdBook = book.IdBook;
            Titl = book.Title;
            Author_Id = book.AuthorId;
            ibsn = book.ISBN;
            Pric = book.Price;
            Description = book.Description;
            Used = book.Used;
            InStock = book.InStock;
            Cover = book.Cover;
            Publisher = book.Publisher;
            Ganre = book.Ganre;
            Tags = book.Tags;
            ReleasYear = book.ReleasYear;
        }

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