using LabMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LabMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()  // Action
        {
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

        public IActionResult About()
        {
            return View();
        }

        public IActionResult MyAction(string id)
        {

            return View();
        }

        public IActionResult MyAction02(string id , string Name)
        {

            var q = new { Name = Name, Id = id , Age = 100 };

            string result = $"{q.Name} , {q.Id}, {q.Age}"; 

            return View();
        }



    }
}
