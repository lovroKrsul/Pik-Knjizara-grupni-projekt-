using PIK_Library.Dal;
using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIK_Knjizara.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            IList<Book> books = (System.Web.HttpContext.Current.Application["database"] as IRepo).LoadBooks();
            foreach (Book book in books)
            {
                book.Cover = "data:image/jpeg;base64," + book.Cover;
            }
            return View(books);
        }

    }
}