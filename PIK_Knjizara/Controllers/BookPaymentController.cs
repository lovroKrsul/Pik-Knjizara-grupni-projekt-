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
            GetBook book = repo.LoadPurchase(id);
            book.Book.Cover = "data:image/jpeg;base64," + book.Book.Cover;
            return View(book);
        }

        public ActionResult PayBuy(int id)
        {
            if (ModelState.IsValid)
            {
                repo.PayPurchase(id);
                return RedirectToAction("Bought", id);
            }
            return View();
        }

        public ActionResult PaymentBorrow(int id)
        {
            GetBook book = repo.LoadPurchase(id);
            book.Book.Cover = "data:image/jpeg;base64," + book.Book.Cover;
            return View(book);
        }

        public ActionResult PayBorrow(int id)
        {
            if (ModelState.IsValid)
            {
                repo.PayPurchase(id);
                return RedirectToAction("Borrowed", id);
            }
            return View();
        }

        public ActionResult Bought(int id)
        {
            GetBook book = repo.LoadPurchase(id);
            if (!book.InStorePayment && !book.Payed)
            {
                return RedirectToAction("PaymentBuy", id);
            }
            book.Book.Cover = "data:image/jpeg;base64," + book.Book.Cover;
            return View(book);
        }

        public ActionResult Borrowed(int id)
        {
            GetBook book = repo.LoadBorrow(id);
            if (!book.InStorePayment && !book.Payed)
            {
                return RedirectToAction("PaymentBorrow", id);
            }
            book.Book.Cover = "data:image/jpeg;base64," + book.Book.Cover;
            return View(book);
        }
    }
}