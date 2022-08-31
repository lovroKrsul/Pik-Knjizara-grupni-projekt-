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
    public class HomeController : Controller
    {
        IRepo repo = (System.Web.HttpContext.Current.Application["database"] as IRepo);
        public ActionResult Index()
        {
            IList<Book> books = repo.LoadBooks();
            foreach (Book book in books)
            {
                book.Cover = "data:image/jpeg;base64," + book.Cover; 
            }

            IList<Book> mostPopular = repo.LoadMostPopularBooks();
            foreach (Book book in mostPopular)
            {
                book.Cover = "data:image/jpeg;base64," + book.Cover;
            }
            ViewBag.MostPopular = mostPopular;

            if (Session["user"] != null)
            {
                User user = (User)Session["user"];
                IList<ReturnBook> userBorrows = repo.LoadReturns().Where(b => b.UserId == user.IdUser).ToList();
                ViewBag.UserReturns = userBorrows;
            }


            return View(books);
        }


        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            User user = (User)Session["worker"];
            if (user != null)
            {
                return RedirectToAction("Index", "WorkerDashboard");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Cryptography.HashPassword(user.Password);
                User authUser = (System.Web.HttpContext.Current.Application["database"] as IRepo).AuthenticateUser(user.Email, user.Password);


                if (authUser == null)
                {
                    ViewBag.NoUser = "Provjerite upisane podatke";
                    return LogIn();
                }

                if (authUser.Workplace != null && authUser.Workplace != "")
                {
                    Session["worker"] = authUser;
                    return RedirectToAction("Index", "WorkerDashboard");
                }
                if (authUser.PersonCode != null && authUser.PersonCode != "")
                {
                    Session["user"] = authUser;
                    return RedirectToAction("Index", "Home");
                }
            }

            return LogIn();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactUs contact)
        {
            if (ModelState.IsValid)
            {
                repo.AddContact(contact);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
