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
    public class SeedController : Controller
    {
        private readonly IRepository<Language> _languages;

        public SeedController (IRepository<Language> languages)
        {
          _languages = languages;
        }

        public async Task<ActionResult> Languages(bool delete)
        {
            if (delete)
            {
                foreach (var language in await _languages.GetAllAsync())
                {
                    await _languages.DeleteAsync(language);
                }

                return Content($"All languages deleted");
            }

            var languages = await _languages.GetAllAsync();

            if (!languages.Any())
            {
                var newLanguages = new List<Language>
                {
                    new Language { Name = "Apache", Tag = "apache" },
                    new Language { Name = "Bash", Tag = "bash" },
                    new Language { Name = "C#", Tag = "csharp" },
                    new Language { Name = "C++", Tag = "cpp" },
                    new Language { Name = "CSS", Tag = "css" },
                    new Language { Name = "CoffeeScript", Tag = "coffeescript" },
                    new Language { Name = "Diff", Tag = "diff" },
                    new Language { Name = "HTML, XML", Tag = "html" },
                    new Language { Name = "HTTP", Tag = "http" },
                    new Language { Name = "Ini", Tag = "ini" },
                    new Language { Name = "JSON", Tag = "json" },
                    new Language { Name = "Java", Tag = "java" },
                    new Language { Name = "JavaScript", Tag = "javascript" },
                    new Language { Name = "Makefile", Tag = "makefile" },
                    new Language { Name = "Markdown", Tag = "markdown" },
                    new Language { Name = "Nginx", Tag = "nginx" },
                    new Language { Name = "Objective-C", Tag = "objectivec" },
                    new Language { Name = "PHP", Tag = "php" },
                    new Language { Name = "Perl", Tag = "perl" },
                    new Language { Name = "Python", Tag = "python" },
                    new Language { Name = "Ruby", Tag = "ruby" },
                    new Language { Name = "SQL", Tag = "sql" }
                };

                foreach (var language in newLanguages)
                {
                    await _languages.AddAsync(language);
                }

                return Content($"{newLanguages.Count} Languages created");
            }

            return Content("Existing languages found. Provide delete parameter to remove");
        }
    }
}