using Pasted.DataAccess;
using Pasted.Domain;
using Pasted.Services;
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
        private readonly IPasteService _pasteService;

        public HomeController(IUnitOfWork unitOfWork, IRepository repository, IPasteService pasteService)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _pasteService = pasteService;
        }

        public ActionResult Index()
        {
            // Get all 'Paste' entities from repository
            var model = _repository.GetAll<Paste>();

            //_pasteService.GetAll();

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