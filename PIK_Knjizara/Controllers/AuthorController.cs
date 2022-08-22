using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PIK_Knjizara.Models.ViewModels;
using PIK_Library.Dal;
using PIK_Library.Model;

namespace PIK_Knjizara.Controllers
{
    public class AuthorController : Controller
    {
        IRepo repo = (System.Web.HttpContext.Current.Application["database"] as IRepo);


        // GET: Author
        public ActionResult Index()
        {
            return View();
        }

        // GET: Author/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Author/Create
        public ActionResult Create()
        {
            return View("AddAuthor");
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {


                repo.AddAuthor(new Author { FirstName = collection["FirstName"], LastName = collection["LastName"], Description = collection["Description"], Biography = collection["Biography"] });

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit()
        {
            return View("UpdateAuthor");

        }


        // GET: Author/Edit/5


        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {


            try
            {
                int i = repo.UpdateAuthorByName(new Author { FirstName = collection["FirstName"], LastName = collection["LastName"], Description = collection["Description"], Biography = collection["Biography"] });
                if (i > 0)
                {
                    return RedirectToAction("Index");
                }
                return View("UpdateAuthor");
            }
            catch
            {
                return View("UpdateAuthor");
            }
        }

        // GET: Author/Delete/5
        public ActionResult Delete()
        {
            ViewBag.authors = repo.LoadAuthors();
            return View("DeleteAuthor");
        }

        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            string author = Request.Form["Author:"].ToString(); ;
            try
            {
                Author a = repo.LoadAuthorByName(author);
                repo.DeleteAuthorByName(a.FirstName + " " + a.LastName);
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View("DeleteAuthor");
            }
        }
        
        public ActionResult AuthorDetails(int id)
        {
            return View("AuthorDetails", model: repo.LoadAuthor(id));
        }
        public ActionResult LoadBooks(int id)
        {
            IList<Book> Books = new List<Book>();
            Books = (IList<Book>)repo.LoadBooks().Where(Book => Book.IdBook == id).ToList();
            return PartialView("_AuthorBooks", model: Books);
        }

    }

}
