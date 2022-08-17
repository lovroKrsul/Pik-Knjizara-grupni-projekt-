using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIK_Knjizara.Models.ViewModels
{
    public class GetBookVM
    {
        public Book Book { get; set; }
        public bool PaymentMethod { get; set; }
        public bool Delivery { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}