using PIK_Library.Dal;
using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIK_Knjizara.Controllers
{
    public class BookPaymentController : Controller
    {
        IRepo repo = (System.Web.HttpContext.Current.Application["database"] as IRepo);

        public ActionResult PaymentBuy(int id)
        {
            User user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            GetBook book = repo.LoadPurchase(id);
            book.Book.Cover = "data:image/jpeg;base64," + book.Book.Cover;
            return View(book);
        }

        public ActionResult PayBuy(int id)
        {
            User user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            if (ModelState.IsValid)
            {
                repo.PayPurchase(id);
                return RedirectToAction("Bought", new { Id = id });
            }
            return View();
        }

        public ActionResult PaymentBorrow(int id)
        {
            User user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            GetBook book = repo.LoadBorrow(id);
            book.Book.Cover = "data:image/jpeg;base64," + book.Book.Cover;
            return View(book);
        }

        public ActionResult PayBorrow(int id)
        {
            User user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            if (ModelState.IsValid)
            {
                repo.PayBorrow(id);
                return RedirectToAction("Borrowed", new { Id = id });
            }
            return View();
        }

        public ActionResult Bought(int id)
        {
            User user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            GetBook book = repo.LoadPurchase(id);
            if (!book.InStorePayment && !book.Payed)
            {
                return RedirectToAction("PaymentBuy", new { Id = id });
            }
            book.Book.Cover = "data:image/jpeg;base64," + book.Book.Cover;
            return View(book);
        }

        public ActionResult Borrowed(int id)
        {
            User user = (User)Session["user"];
            if (user == null)
            {
                return RedirectToAction("LogIn", "Home");
            }
            GetBook book = repo.LoadBorrow(id);
            if (!book.InStorePayment && !book.Payed)
            {
                return RedirectToAction("PaymentBorrow", new { Id = id });
            }
            book.Book.Cover = "data:image/jpeg;base64," + book.Book.Cover;
            return View(book);
        }
    }
}