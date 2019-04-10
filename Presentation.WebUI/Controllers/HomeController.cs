using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLibrary;
using Microsoft.AspNetCore.Mvc;
using Presentation.WebUI.Models;

namespace Presentation.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDateTime _datetime;

        public HomeController(IDateTime datetime)
        {
            _datetime = datetime;
        }

        public IActionResult Index()
        {
            ViewBag.godzina = _datetime.Now;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
