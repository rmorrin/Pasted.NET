using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pasted.Models;
using Pasted.Data.Repositories;
using System.Threading.Tasks;
using Pasted.ViewModels.ManageViewModels;

namespace Pasted.Controllers
{
    public class PasteController : Controller
    {
        private readonly IPasteRepository _pasteRepository;
        private readonly IRepository<Language> _repository;

        public PasteController (IPasteRepository pasteRepository, IRepository<Language> repository)
        {
            _pasteRepository = pasteRepository;
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Languages"] = await _repository.GetAllAsync();

            return View();
        }

        public async Task<IActionResult> Create(CreatePasteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var language = await _repository.FindOneAsync(m => m.Id == model.Language);

                var paste = new Paste
                {
                    Content = model.Content,
                    Language = language
                };

                await _pasteRepository.AddAsync(paste);

                return RedirectToAction("View", new { id = paste.Id });
            }

            return View("Index", model);
        }

        public async Task<IActionResult> View(int id)
        {
            var paste = await _pasteRepository.FindOneAsync(p => p.Id == id);

            if (paste == null)
            {
                return new NotFoundResult();
            }

            return View(paste);
        }
    }
}