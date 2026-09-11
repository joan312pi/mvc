using LabMVC.Models.NorthwindDbContext;
using LabMVC.Models.ViewModel;
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
            //var q = _dbcontext.Orders;

            var q = from o in _dbcontext.Orders
                    join e in _dbcontext.Employees
                    on o.EmployeeID equals e.EmployeeID
                    select new OrdersViewModel
                    {
                        OrderID = o.OrderID,
                        CustomerID = o.CustomerID,
                        EmployeeName = e.FirstName + " " + e.LastName,
                        OrderDate = o.OrderDate,
                        RequiredDate = o.RequiredDate,
                        ShippedDate = o.ShippedDate,
                        Freight =o.Freight
                    };

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
