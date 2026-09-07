using Lab_Form;
using LabMVC.Models.JsonLab;
using Microsoft.AspNetCore.Mvc;

namespace LabMVC.Controllers
{
    public class LabController : Controller
    {

        private readonly IWebHostEnvironment _env;
        public LabController(IWebHostEnvironment env)
        {
            _env = env;
        }



        public IActionResult RedirectView()
        {
            return View("Index");
        }

        public IActionResult ReturnFile(string id)
        {
            //return File("~/images/cheahcea.jpg", "image/jpeg");

            string path = Path.Combine(_env.WebRootPath, "images", $"CheaChea{id}.jpg");

            if (!System.IO.File.Exists(path))
                return NotFound("找不到啦");

            return PhysicalFile(path, "image/jpeg");
        }

        public IActionResult ReturnJson(string id)
        {
            //return Json(new
            //{
            //    id = id,
            //    Name = "寶寶",
            //    age = 1
            //});

            //Member member = new Member
            //{
            //    Name = "寶寶",
            //    Phone = id,
            //    BirthDate = new DateTime(1999, 1, 10)
            //};

            //return Ok(member);

            var db = new JsonLab();

            return Json(db.Customers);
        }

        public string ReturnString()
        {
            return $"<h2>回傳字串的action</h2>";
        }

        public IActionResult ReturnHtml(string id)
        {
            return Content($"<h2>回傳HTML的action</h2> <h1>{id}</h1>" , "text/html; charset=utf-8");
        }

        public IActionResult ReturnText()
        {
            return Content("<h2>回傳HTML的action</h2>", "text/plain; charset=utf-8");
        }

        public IActionResult RedirectAction()
        {
            //return Redirect("~/Home/MyAction");
            return Redirect("https://www.google.com/");
        }

        public IActionResult redirectToAction()
        {
            //return RedirectToAction("Index");
            return RedirectToAction("MyAction", "Home");
        }

        //[NonAction]
        public IActionResult redirectToAction02()
        {
            return RedirectToAction("MyAction02", "Home",
                new
                {
                    id = "10000",
                    Name = "John"
                });
        }

        public IActionResult Index()
        {
            ViewData["Message"] = "這是ViewData傳給view的資料";
            TempData["TempMessage"] = "這是TempData的資料";
            return View();
        }

        // 比較View("Index")與RedirectToAction("Index")
        public IActionResult ToView()
        {
            return View("Index");
        }

        public IActionResult ToAction()
        {
            return RedirectToAction("Index");
        }

        public IActionResult TempDataRedirect()
        {
            TempData["TempMessage"] = "TempData到其他Action";
            ViewData["Message"] = "ViewData到其他Action";
            return RedirectToAction("TempDataView");
        }

        public IActionResult TempDataView()
        {
            return View();
        }

        [Route("GetCustomer/{country?}")]
        public IActionResult ViewBagView(string country)
        {
            ViewBag.Message = "這是ViewBag的資料";

            var q = new JsonLab().Customers;

            if (!string.IsNullOrWhiteSpace(country))
            {
                ViewBag.GetCustomers = q.Where(c => c.Country.Contains(country)).ToList();
            }else
            {
                ViewBag.GetCustomers = q;
            }
            
            return View();
        }

        //bool Country (Customer customer)
        //{
        //    return customer.Country.Contains("city");
        //}


        public IActionResult CompareVDVBTD()
        {
            ViewData["CurrentTimeViewData"] = DateTime.Now;
            TempData["CurrentTimeTempData"] = DateTime.Now;
            ViewBag.CurrentTiemViewBag = DateTime.Now;

            return RedirectToAction("VRedirectAction");
        }
           
        public IActionResult VRedirectAction()
        {
            return View();
        }

        //[HttpGet("MyGet")]
        public IActionResult GetMethod(string Name , int Id)
        {
            return Json(new
            {
                Name = Name,
                Id = Id
            });
        }

        [HttpPost]
        public IActionResult PostMethod(string Name , int Id)
        {
            return Json(new
            {
                PostName = Name,
                PostId = Id
            });
        }



    }
}
