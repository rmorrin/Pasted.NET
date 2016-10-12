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
        private readonly ILanguageRepository _languageRepository;

        public PasteController (IPasteRepository pasteRepository, ILanguageRepository languageRepository)
        {
            _pasteRepository = pasteRepository;
            _languageRepository = languageRepository;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Languages"] = await _languageRepository.GetAllAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePasteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var language = await _languageRepository.FindOneAsync(m => m.Id == model.Language);

                var paste = new Paste
                {
                    Content = model.Content,
                    Language = language
                };

                await _pasteRepository.AddAsync(paste);

                return RedirectToAction("View", new { id = paste.Id });
            }

            ViewData["Languages"] = await _languageRepository.GetAllAsync();

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