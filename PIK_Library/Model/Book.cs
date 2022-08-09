using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIK_Library.Model
{
    public class Book
    {
        public int IdBook { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public string Description { get; set; }
        public string IBAN { get; set; }
        public string Info { get; set; }
        public string Other { get; set; }
        public double Price { get; set; }
    }
}
