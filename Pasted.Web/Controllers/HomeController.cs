using Pasted.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pasted.Web.Controllers
{
    public class HomeController : Controller
    {
        // Note: This is just temporary,
        // In reality, we will not be using
        // the db context directly, and will use
        // a repository instead.
        private readonly PastedDbContext _db;

        public HomeController()
        {
            // TODO: Set up IoC to inject dependencies into controllers
            _db = new PastedDbContext();
        }

        public ActionResult Index()
        {
            return View(_db.Pastes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}