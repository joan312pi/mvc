using LabMVC.Models.JsonLab;
using LabMVC.Models.TagHelperLab;
using Microsoft.AspNetCore.Mvc;

namespace LabMVC.Controllers
{
    public class ModelLabController : Controller
    {
        public IActionResult Index()
        {
            Customer? q = new JsonLab().Customers
                .Where(c => c.Country == "USA")
                .FirstOrDefault();

            return View(q);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Customer? q = new JsonLab().Customers
                .Where(c => c.CustomerID == id).FirstOrDefault();
            return View(q);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            return View("Index",customer);
        }


        public IActionResult TagHelpers()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TagHelpers(Member member)
        {
            return View(member);
        }


    }
}
