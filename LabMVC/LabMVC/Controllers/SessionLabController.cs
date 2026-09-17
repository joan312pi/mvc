using Microsoft.AspNetCore.Mvc;

namespace LabMVC.Controllers
{
    public class SessionLabController : Controller
    {
        public async Task<IActionResult> SetSession()
        {
            HttpContext.Session.SetString("UserName", "John");
            HttpContext.Session.SetInt32("Age", 18);

            return Json(new
            {
                Message = $"已存入Session"
            });
        }

        public async Task<IActionResult> GetSession()
        {
            string? Name = HttpContext.Session.GetString("UserName");
            int? Age = HttpContext.Session.GetInt32("Age");

            return Json(new
            {
                Message = $"{Name} 的年齡為 {Age}"
            });
        }


    }
}
