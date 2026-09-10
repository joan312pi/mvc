using LabMVC.Models;
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

        public IActionResult RequestFormLab()
        {
            return View();
        }

        [HttpPost]
        public string RequestFormSubmit()
        {
            return $"Email: {Request.Form["Email"]}," +
                $" Password: {Request.Form["Password"]}";
        }

        public IActionResult RequestFromForm([FromForm] string Email
            , [FromForm] string Password)
        {
            return Json(new
            {
                帳號= Email,
                密碼=Password
            });
        }

        [HttpPost]
        public IActionResult RequestFromModel(LoginViewModel login)
        {
            return Json(new
            {
                帳號 = login.Email,
                密碼 = login.Password
            });
        }

    }
}
