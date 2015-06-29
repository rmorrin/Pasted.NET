using Pasted.DataAccess;
using Pasted.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pasted.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository _repository;

        public HomeController(IUnitOfWork unitOfWork, IRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public ActionResult Index()
        {
            // Get all 'Paste' entities from repository
            var model = _repository.GetAll<Paste>();

            return View(model);
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