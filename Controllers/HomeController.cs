using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pasted.Data.Repositories;

namespace Pasted.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public async Task<IActionResult> CreateLanguages()
        {
            // var csharp = new Models.Language
            // {
            //     Name = "C#",
            //     PrismName = "csharp"
            // };

            // var js = new Models.Language
            // {
            //     Name = "JavaScript",
            //     PrismName = "javascript"
            // };

            // await _repository.AddAsync(csharp);
            // await _repository.AddAsync(js);

            // return Content("Success");
            throw new NotImplementedException();
        }
    }
}
