using FillDb.Repo;
using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsonRepo repo = new JsonRepo();
            IList<Book> books = repo.LoadBooks();
        }
    }
}
