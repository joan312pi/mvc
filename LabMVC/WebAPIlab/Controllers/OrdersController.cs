using LabMVC.Models.NorthwindDbContext;
using LabMVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIlab.Data;

namespace LabMVC.Controllers
{
  
    [Route("api/[controller]")]
    //[ApiController]
    public class OrdersController : Controller
    {
        private NorthwindDbContext _dbcontext;
        public OrdersController(NorthwindDbContext northwindDbContext)
        {
            _dbcontext = northwindDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
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
                        Freight = o.Freight
                    };

            return Ok(await q.ToListAsync());
        }

        [HttpGet("Details/{id}")]
        public async Task< IActionResult> Details(int id)
        {
            return Ok(await _dbcontext.Orders.FirstOrDefaultAsync(o => o.OrderID == id));
        }

        public IActionResult Edit(int id)
        {
            return Ok(_dbcontext.Orders.FirstOrDefault(o => o.OrderID == id));
        }

        [HttpPut]
        public IActionResult Edit(Order order)
        {
            _dbcontext.Orders.Update(order);
            _dbcontext.SaveChanges();
            return Ok(order);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult Create(Order order)
        {
            _dbcontext.Orders.Add(order);
            _dbcontext.SaveChanges();
            return Ok(new { Message = "新增會員成功" });
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
