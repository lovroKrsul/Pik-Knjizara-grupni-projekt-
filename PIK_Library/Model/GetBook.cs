using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIK_Library.Model
{
    public class GetBook
    {
        public int IdPurchase { get; set; }
        public int IdBorrow { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public Book Book { get; set; }
        [Display(Name = " ")]
        public bool InStorePayment { get; set; }
        public bool Payed { get; set; }
        public bool Delivery { get; set; }
        [Display(Name = "Return Date")]
        public User User { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
