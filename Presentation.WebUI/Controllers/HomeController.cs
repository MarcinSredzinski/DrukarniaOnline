using ApplicationLibrary;
using CoreLibrary.Entities.Relations;
using Microsoft.AspNetCore.Mvc;
using Persistance.RepositoryLibrary;
using PersistenceLibrary;
using Presentation.WebUI.Models;
using System.Collections.Generic;
using System.Diagnostics;

namespace Presentation.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDateTime _datetime;
        private readonly DrukarniaDbContext _dbContext;
        public HomeController(DrukarniaDbContext drukarniaDbContext, IDateTime datetime)
        {
            _datetime = datetime;
            _dbContext = drukarniaDbContext;
        }

        public IActionResult Index()
        {
            /*
             *    <td>@Html.TextBox("tb1", element.Employee.FirstName)</td>
                    <td>@Html.TextArea("ta1", element.Equipment.Name)</td>
             */
            EmployeeRepository employeeRepository = new EmployeeRepository(_dbContext);
            List<EmployeeEquipment> abc = employeeRepository.GetUsersEquipment(1);
            ViewBag.godzina = _datetime.Now;
            ViewData["eq"] = abc;
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
