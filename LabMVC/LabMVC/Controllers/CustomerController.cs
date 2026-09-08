using LabMVC.Models.NorthwindDbContext;
using Microsoft.AspNetCore.Mvc;

namespace LabMVC.Controllers
{
    public class CustomerController : Controller
    {
        private NorthwindDbContext _dbcontext;
        public CustomerController(NorthwindDbContext northwindDbContext)
        {
            _dbcontext= northwindDbContext;
        }


        public IActionResult Index()
        {
            var q = _dbcontext.Customers;
            return View(q);
        }
    }
}
