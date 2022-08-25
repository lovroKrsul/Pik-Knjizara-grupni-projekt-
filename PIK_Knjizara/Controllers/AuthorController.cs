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
           User user = (User)Session["worker"];
            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            IList<Author> authors=repo.LoadAuthors();
            
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
            User user = (User)Session["worker"];
            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
         
            return View("AddAuthor");
        }

        // POST: Author/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            User user = (User)Session["worker"];
            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }

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
            User user = (User)Session["worker"];
            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
             
            ViewBag.authors = repo.LoadAuthors();
            return View("UpdateAuthor");
           
        }


        // GET: Author/Edit/5


        // POST: Author/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            User user = (User)Session["worker"];
            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            
            var x = collection["Author:"];
            string ID = x.Split(':').First();
            ViewBag.authors = repo.LoadAuthors();
            try
            {
                Author a=repo.LoadAuthorByID(int.Parse(ID));
                int i = repo.UpdateAuthorByID(new Author {ID=a.ID,FirstName = collection["FirstName"], LastName = collection["LastName"], Description = collection["Description"], Biography = collection["Biography"] });
                // int i = repo.UpdateAuthorByName(new Author { FirstName = collection["FirstName"], LastName = collection["LastName"], Description = collection["Description"], Biography = collection["Biography"] });
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
            User user = (User)Session["worker"];
            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
             
            ViewBag.authors = repo.LoadAuthors();
            return View("DeleteAuthor");
        }

        // POST: Author/Delete/5
        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            User user = (User)Session["worker"];
            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
             
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
        public ActionResult GetAutocompleteAuthors(string term)
        {
            IList<Author> auth = repo.LoadAuthors();

            var find = auth.Where(a => a.ToString().ToLower().Contains(term.ToLower())).Select(a => new
            {
                label = a.ToString(),
                value = a.ID.ToString(),
            });

            return Json(find, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AuthorDetails(int id)
        {
            return View("AuthorDetails", model: repo.LoadAuthor(id));
        }

        public ActionResult LoadBooks(int id)
        {
            IList<Book> Books = new List<Book>();
            Books = (IList<Book>)repo.LoadBooks().Where(Book => Book.AuthorId == id).ToList();
            return PartialView("_AuthorBooks", model: Books);
        }

    }
   
}
