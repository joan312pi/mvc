using Microsoft.AspNetCore.Mvc;

namespace LabMVC.Controllers
{

    [Route("Route/{action=index}")]
    public class MyRouteController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        [Route("MyRoute/{Name?}")]
        public IActionResult Index02(string Name)
        {

            return View();
        }

        public IActionResult RouteAbout()
        {
            return View();
        }

    }
}
