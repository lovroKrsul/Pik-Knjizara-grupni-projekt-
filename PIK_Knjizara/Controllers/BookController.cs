using PIK_Knjizara.Models.ViewModels;
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

        public ActionResult GetBook(int id)
        {
            GetBook getBookVM = new GetBook();
            Book book = repo.LoadBook(id);
            book.Cover = "data:image/jpeg;base64," + book.Cover;
            getBookVM.Book = book;
            getBookVM.ReturnDate = DateTime.Now.AddDays(1);
            return View(getBookVM);
        }

        [HttpPost]
        public ActionResult GetBook(GetBook book)
        {
            if (ModelState.IsValid)
            {
                if (book.Buy)
                {
                    BuyBook(book);
                }
                else
                {
                    BorrowBook(book);
                }
            }
            return View();
        }

        private void BorrowBook(GetBook book)
        {
            User user = (User)Session["user"];
            book.User = repo.LoadUser(user.Email);
            repo.AddBorrow(book);
        }

        private void BuyBook(GetBook book)
        {
            User user = (User)Session["user"];
            book.User = repo.LoadUser(user.Email);
            repo.AddPurchase(book);
        }

        public ActionResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBook(AddBookVM book)//, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)//&& image != null && image.ContentLength > 0)
            {

            }
            return View();
        }
    }
}