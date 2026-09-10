using LabMVC.Models.NorthwindDbContext;
using Microsoft.AspNetCore.Mvc;

namespace LabMVC.Controllers
{
    public class OrdersController : Controller
    {
        private NorthwindDbContext _dbcontext;
        public OrdersController(NorthwindDbContext northwindDbContext)
        {
            _dbcontext = northwindDbContext;
        }

        public IActionResult Index()
        {
            var q = _dbcontext.Orders;
           return View(q);
        }

        public IActionResult Details(int id)
        {
            return View(_dbcontext.Orders.FirstOrDefault(o => o.OrderID == id));
        }

        public IActionResult Edit(int id)
        {
            return View(_dbcontext.Orders.FirstOrDefault(o => o.OrderID == id));
        }

        [HttpPost]
        public IActionResult Edit(Order order)
        {
            _dbcontext.Orders.Update(order);
            _dbcontext.SaveChanges();
            return View("Details", order);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            _dbcontext.Orders.Add(order);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            return View(_dbcontext.Orders.FirstOrDefault(o => o.OrderID == id));
        }

        [HttpPost]
        public IActionResult Delete(Order order)
        {
            _dbcontext.Orders.Remove(order);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
