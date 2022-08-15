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
    public class WorkerController : Controller
    {
        private IList<User> _allUsers;
        private IRepo repo = (System.Web.HttpContext.Current.Application["database"] as IRepo);

        // GET: Worker
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddWorker()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddWorker(AddWorkerModel user)
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
                    user.Password = Cryptography.HashPassword(user.Password);
                    repo.AddUser(user);
                    Session["worker"] = user;

                    return RedirectToAction("Index", "Home");
                }
            }

            return AddWorker();
        }
        public ActionResult UpdateWorker(int id)
        {
            /*if (Session["worker"] == null)
            {
                return RedirectToAction("Index", "Home");
            }*/
            User user;
            if (id != null)
            {
                user = repo.LoadUserId(id);
            }
            else
            {
                User userE = (User)Session["worker"];
                user = repo.LoadUser(userE.Email);
            }
            UpdateWorkerModel worker = new UpdateWorkerModel(user);

            return View(worker);
        }

        [HttpPost]
        public ActionResult UpdateWorker(UpdateWorkerModel user)
        {
            if (ModelState.IsValid)
            {

                if (user.OldPassword != null && user.NewPassword != null)
                {
                    user.OldPassword = Cryptography.HashPassword(user.OldPassword);
                    user.NewPassword = Cryptography.HashPassword(user.NewPassword);
                    if (user.Password != user.OldPassword)
                    {
                        return View();
                    }
                    user.Password = user.NewPassword;
                }
                user.FirstName = user.FName;
                user.LastName = user.LName;
                user.Email = user.E_mail;
                (System.Web.HttpContext.Current.Application["database"] as IRepo).UpdateUser(user as User);
                return RedirectToAction("Index", "WorkerDashboard");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            IRepo repo = (System.Web.HttpContext.Current.Application["database"] as IRepo);
            User user = repo.LoadUserId(id);
            user.FirstName = Cryptography.HashPassword(user.FirstName);
            user.LastName = user.FirstName;
            user.Email = user.FirstName;
            user.Password = user.FirstName;
            user.OIB = user.FirstName;

            repo.DeleteWorker(user);
            return RedirectToAction("LogOut", "Home");
        }
    }
}