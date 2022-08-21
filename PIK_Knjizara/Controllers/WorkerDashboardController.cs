﻿using PIK_Library.Dal;
using PIK_Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PIK_Knjizara.Controllers
{
    public class WorkerDashboardController : Controller
    {
        IRepo repo = (System.Web.HttpContext.Current.Application["database"] as IRepo);
        // GET: WorkerDashboard
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageWorkers()
        {
            IList<User> users = repo.LoadUsers();
            return View(users.Where(u => u.Workplace != null && u.Workplace != "").ToList());
        }

        public ActionResult ManageBooks()
        {
            return View(repo.LoadBooks());
        }

        public ActionResult Users()
        {
            IList<User> persons = repo.LoadUsers();
            return View(persons.Where(u => u.PersonCode != null && u.PersonCode != "").ToList());
        }

        public ActionResult Contacts()
        {
            return View(repo.LoadContacts());
        }

        public ActionResult ContactViewed(int id)
        {
            repo.ContactViewed(id);
            return RedirectToAction("Contacts");
        }

        public ActionResult BookstoreData()
        {
            return View(repo.LoadBookstore());
        }

        [HttpPost]
        public ActionResult BookstoreData(Bookstore bookstore)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateBookstore(bookstore);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult ReturnBooks()
        {
            return View(repo.LoadReturns());
        }

        public ActionResult ReturnBook(int id)
        {
            ReturnBook returnBook = repo.LoadReturn(id);
            if (returnBook.ReturnDate < DateTime.Now)
            {
                returnBook.Overdue = (DateTime.Now - returnBook.ReturnDate).Days;
            }

            return View(returnBook);
        }

        [HttpPost]
        public ActionResult ReturnBook(ReturnBook returnBook)
        {
            if (ModelState.IsValid)
            {
                if (returnBook.Book.Used)
                {
                    returnBook.Book = repo.LoadBook(returnBook.Book.IdBook);
                    repo.AddReturn(returnBook);
                }
                else
                {
                    returnBook.Book = repo.LoadBookUsed(returnBook.Book.Title);
                    repo.AddReturn(returnBook);
                }

                return RedirectToAction("ReturnBooks");
            }

            return View(returnBook);
        }
    }
}