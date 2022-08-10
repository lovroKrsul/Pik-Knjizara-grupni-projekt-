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
        public string Title { get; set; }
        public Author Author { get; set; }
        public string Description { get; set; }
        public string IBAN { get; set; }
        public string Info { get; set; }
        public bool Used { get; set; }
        public int InStock { get; set; }
        public double Price { get; set; }
        public string Cover { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public string Ganre { get; set; }
        public string Tags { get; set; }
        public string Other { get; set; }
    }
}
