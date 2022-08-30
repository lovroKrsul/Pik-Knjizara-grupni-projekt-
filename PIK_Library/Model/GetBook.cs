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
        public int IdGet { get; set; }
        public int IdBook { get; set; }
        public Book Book { get; set; }
        [Display(Name = " ")]
        public bool InStorePayment { get; set; }
        public bool Delivery { get; set; }
        [Display(Name = "Return Date")]
        public User User { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
