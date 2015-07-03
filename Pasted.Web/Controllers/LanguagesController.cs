using Pasted.DataAccess;
using Pasted.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Pasted.Web.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository _repository;

        public LanguagesController(IUnitOfWork unitOfWork, IRepository repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        // GET: Languages
        public ActionResult Index()
        {
            var model = _repository.GetAll<Language>();

            return View(model);
        }

        // GET: Languages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _repository.FindOne<Language>(criteria: i => i.Id == id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // GET: Languages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Languages/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Language language)
        {

            if (ModelState.IsValid)
            {
                _repository.Add<Language>(language);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(language);
        }

        // GET: Languages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _repository.FindOne<Language>(criteria: i => i.Id == id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: Languages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, Language language)
        public ActionResult Edit(int id, Language language)
        {
            if (ModelState.IsValid)
            {
                _repository.Update<Language>(language);
                _unitOfWork.Commit();
                return RedirectToAction("Index");
            }

            return View(language);
        }

        // GET: Languages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = _repository.FindOne<Language>(criteria: i => i.Id == id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComfirmed(int id)
        {
            var model = _repository.FindOne<Language>(criteria: i => i.Id == id);
            _repository.Delete<Language>(model);
            _unitOfWork.Commit();

            return RedirectToAction("Index");
        }
    }
}
