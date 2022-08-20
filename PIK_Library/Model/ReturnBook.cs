using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIK_Library.Model
{
    public class ReturnBook
    {
        public int IdBorrow { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool InStorePayment { get; set; }
        public bool Delivery { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
