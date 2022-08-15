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
        public ActionResult Index()
        {
            IList<Book> books = (System.Web.HttpContext.Current.Application["database"] as IRepo).LoadBooks();
            foreach (Book book in books)
            {
                book.Cover = "data:image/jpeg;base64," + book.Cover;
            }
            return View(books);
        }


        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LogIn()
        {
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
                    return LogIn();
                }

                if (authUser.Workplace != null)
                {
                    Session["worker"] = authUser;
                    return RedirectToAction("Index", "WorkerDashboard");
                }
                if (authUser.PersonCode != null)
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
    }
}
