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
            
            IList<Author> authors= new List<Author>();
            authors=repo.LoadAuthors();
            return View("Index",model:authors);
        }

      
        public ActionResult LoadAuthors()
        {
            IEnumerable<Author> Authors = new List<Author>();
            Authors = repo.LoadAuthors();
            return PartialView("_Authors", model: Authors);
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
         [HttpGet]
        public ActionResult AuthorDetails(int id)
        {
           
            return View("AuthorDetails", model: repo.LoadAuthorByID(id));
            
        }
        

        public ActionResult LoadBooks(int id)
        {
            
            IEnumerable<Book> Books = new List<Book>();
            Books = repo.LoadBooks().Where(Book => Book.AuthorId == id).ToList();
            return PartialView("_AuthorBooks", model: Books);
        }
        public ActionResult GetAutocompleteAuthors(string term)
        {
            IList<Author> Authors = repo.LoadAuthors();
            
            var find = Authors.Where(a => a.ToString().Contains(term.ToLower())).Select(a => new
            {
                label = a.FirstName + " " + a.LastName,
                value = a.ID
            });
            if(find.Count() ==0)
            {
                find = Authors.Where(a => a.LastName.Contains(term.ToLower())).Select(a => new
                {
                    label = a.FirstName + " " + a.LastName,
                    value = a.ID
                });
            }

            return Json(find, JsonRequestBehavior.AllowGet);
        }
    }

}

