using Microsoft.AspNetCore.Mvc;

namespace LabMVC.Areas.Member.Controllers
{
    [Area("Member")]
    //[Route("Member/{controller}/{action=Index}")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
