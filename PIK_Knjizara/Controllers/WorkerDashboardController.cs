using PIK_Library.Dal;
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
            return View(users.Where(u => u.Workplace != null));
        }

        public ActionResult ManageBooks()
        {
            return View(repo.LoadBooks());
        }
    }
}