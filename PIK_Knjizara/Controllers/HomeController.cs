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
        private IList<User> _allUsers;

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
                else
                {
                    Session["user"] = authUser;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return LogIn();
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                IRepo repo = (System.Web.HttpContext.Current.Application["database"] as IRepo);
                _allUsers = repo.LoadUsers();
                if (_allUsers.FirstOrDefault(u => u.Email == user.Email) == null)
                {
                    user.Email = user.E_mail;
                    user.FirstName = user.FName;
                    user.LastName = user.LName;
                    user.Password = user.Pass;
                    user.Pass = null;
                    user.PersonCode = "K" + DateTime.Now.ToString();
                    user.Password = Cryptography.HashPassword(user.Password);
                    RegisterUser(repo, user);
                    Session["user"] = user;

                    return RedirectToAction("Index", "Home");
                }
            }

            return Registration();
        }

        private void RegisterUser(IRepo repo, User user)
        {
            repo.AddUser(user);
        }
    }
}
