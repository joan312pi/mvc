using LabMVC.Models.NorthwindDbContext;
using LabMVC.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace LabMVC.Controllers
{
    public class CustomerController : Controller
    {
        //private NorthwindDbContext _dbcontext;
        //public CustomerController(NorthwindDbContext northwindDbContext)
        //{
        //    _dbcontext= northwindDbContext;
        //}

        private IGenericRepository<Customer> _dbCustomer;
        public CustomerController(IGenericRepository<Customer> cusomerRepository)
        {
            _dbCustomer = cusomerRepository;
        }


        public IActionResult Index()
        {
            //var q = _dbcontext.Customers;
            //return View(q);

            return View(_dbCustomer.GetAll());
        }

        public IActionResult Details(string id)
        {
            //return View(_dbcontext.Customers.FirstOrDefault(c=>c.CustomerID==id));
            return View(_dbCustomer.GetById(id));
        }

        public IActionResult Edit(string id)
        {
            //return View(_dbcontext.Customers.FirstOrDefault(c => c.CustomerID == id));
            return View(_dbCustomer.GetById(id));
        }

        //做出可儲存編輯Edit Customer的action，成功後導向Details頁面

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            //_dbcontext.Customers.Update(customer);
            //_dbcontext.SaveChanges();

            _dbCustomer.Update(customer);
            _dbCustomer.SaveChanges();

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
            //_dbcontext.Customers.Add(customer);
            //_dbcontext.SaveChanges();

            _dbCustomer.Add(customer);
            _dbCustomer.SaveChanges();

            //return View("Index");
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            //return View(_dbcontext.Customers.FirstOrDefault(c => c.CustomerID == id));
            return View(_dbCustomer.GetById(id));
        }

        [HttpPost]
        public IActionResult Delete(Customer customer)
        {
            // 帶入的資料如果有PK，
            // 可以在Remove裡針對PK對應到的資料做刪除
            //_dbcontext.Customers.Remove(customer);            
            //_dbcontext.SaveChanges();

            _dbCustomer.Delete(customer);
            _dbCustomer.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
