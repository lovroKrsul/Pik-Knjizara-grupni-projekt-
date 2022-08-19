using PIK_Knjizara.Models.ViewModels;
using PIK_Library.Dal;
using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIK_Knjizara.Controllers
{
    public class BookController : Controller
    {
        IRepo repo = (System.Web.HttpContext.Current.Application["database"] as IRepo);

        // GET: Book
        public ActionResult Index(int id)
        {
            BookVM books = new BookVM();
            Book book = (System.Web.HttpContext.Current.Application["database"] as IRepo).LoadBook(id);
            book.Cover = "data:image/jpeg;base64," + book.Cover;
            books.NewBook = book;
            book = (System.Web.HttpContext.Current.Application["database"] as IRepo).LoadBookUsed(book.Title);
            book.Cover = "data:image/jpeg;base64," + book.Cover;
            books.OldBook = book;
            return View(books);
        }

        public ActionResult GetAutocompleteBooks(string term)
        {
            IList<Book> books = repo.LoadBooks();

            var find = books.Where(a => a.Title.ToLower().Contains(term.ToLower())).Select(a => new
            {
                label = a.Title,
                value = a.IdBook
            });

            return Json(find, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddBook()
        {
            ViewBag.authors = repo.LoadAuthors();
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(AddBookVM book, HttpPostedFileBase file)
        {
            if (ModelState.IsValid && file != null && file.ContentLength > 0)
            {
                book.Cover = SavePicture(file);
                book.Title = book.Titl;
                book.ISBN = book.ibsn;
                book.Price = book.Pric;
                book.AuthorId = book.Author_Id;

                repo.AddBook(book);

                return RedirectToAction("Index", "WorkerDashboard");
            }

            ViewBag.authors = repo.LoadAuthors();
            return View();
        }

        public ActionResult UpdateBook(int id)
        {
            UpdateBookVM book = new UpdateBookVM(repo.LoadBook(id));
            book.Authors = repo.LoadAuthors();
            return View(book);
        }

        [HttpPost]
        public ActionResult UpdateBook(UpdateBookVM book, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.ContentLength > 0)
                {
                    book.Cover = SavePicture(file);
                }
                book.Title = book.Titl;
                book.ISBN = book.ibsn;
                book.Price = book.Pric;
                book.AuthorId = book.Author_Id;

                repo.UpdateBook(book);

                return RedirectToAction("ManageBooks", "WorkerDashboard");
            }

            ViewBag.authors = repo.LoadAuthors();
            return View();
        }

        private string SavePicture(HttpPostedFileBase file)
        {
            MemoryStream picture = new MemoryStream();
            file.InputStream.CopyTo(picture);
            byte[] bytes = picture.ToArray();
            return Convert.ToBase64String(bytes);
        }
    }
}