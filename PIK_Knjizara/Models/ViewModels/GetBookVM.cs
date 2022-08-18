using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PIK_Knjizara.Models.ViewModels
{
    public class GetBookVM
    {
        public Book Book { get; set; }
        [Display (Name = "Payment method:")]
        public bool PaymentMethod { get; set; }
        public bool Delivery { get; set; }
        [Display (Name = "Return Date")]
        public DateTime ReturnDate { get; set; }
    }
}