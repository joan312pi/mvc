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

        public IActionResult Details(string id)
        {
            return View(_dbcontext.Customers.FirstOrDefault(c=>c.CustomerID==id));
        }

        public IActionResult Edit(string id)
        {
            return View(_dbcontext.Customers.FirstOrDefault(c => c.CustomerID == id));
        }

        //做出可儲存編輯Edit Customer的action，成功後導向Details頁面

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _dbcontext.Customers.Update(customer);
            _dbcontext.SaveChanges();
            return View("Details", customer);
            //return RedirectToAction("Details");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _dbcontext.Customers.Add(customer);
            _dbcontext.SaveChanges();
            //return View("Index");
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            return View(_dbcontext.Customers.FirstOrDefault(c => c.CustomerID == id));
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            // 帶入的資料如果有PK，
            // 可以在Remove裡針對PK對應到的資料做刪除
            _dbcontext.Customers.Remove(customer);            
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
