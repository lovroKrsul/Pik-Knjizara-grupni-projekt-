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
    public class UserController : Controller
    {
        private IList<User> _allUsers;

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel user)
        {
            if (ModelState.IsValid)
            {
                IRepo repo = (System.Web.HttpContext.Current.Application["database"] as IRepo);
                _allUsers = repo.LoadUsers();

                if ((_allUsers.FirstOrDefault().Email = user.Email) != null)
                {
                    return RedirectToAction("ConfirmPasswordReset", "User");
                }
            }
            return View();
        }

        public ActionResult ConfirmPasswordReset()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConfirmPasswordReset(PasswordResetVM user)
        {
            if (ModelState.IsValid)
            {
                user.Password = Cryptography.HashPassword(user.Pass);
                user.Pass = null;
                user.ConfirmPassword = null;
                user.Email = user.E_mail;

                IRepo repo = (System.Web.HttpContext.Current.Application["database"] as IRepo);
                _allUsers = repo.LoadUsers();

                if ((_allUsers.FirstOrDefault().Email = user.Email) != null)
                {
                    repo.ResetPassword(user as User);
                    RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult UpdateUser()
        {
            if (Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            User user = (User)Session["user"];
            UpdateUserModel userid = new UpdateUserModel((System.Web.HttpContext.Current.Application["database"] as IRepo).LoadUser(user.Email));

            return View(userid);
        }

        [HttpPost]
        public ActionResult UpdateUser(UpdateUserModel user)
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
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}