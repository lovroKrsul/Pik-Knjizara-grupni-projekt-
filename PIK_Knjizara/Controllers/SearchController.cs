using PIK_Library.Dal;
using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIK_Knjizara.Controllers
{
    public class SearchController : Controller
    {
        IRepo repo = (System.Web.HttpContext.Current.Application["database"] as IRepo);

        // GET: Search
        public ActionResult BookSearch()
        {
            IList<Book> books = repo.LoadBooks();
            foreach (Book book in books)
            {
                book.Cover = "data:image/jpeg;base64," + book.Cover;
            }
            return View(books);
        }

        public ActionResult AuthorSearch()
        {
            IList<Author> authors = repo.LoadAuthors();
            return View(authors);
        }
    }
}