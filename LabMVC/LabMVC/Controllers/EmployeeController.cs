using Azure.Core;
using LabMVC.Models.NorthwindDbContext;
using LabMVC.Models.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace LabMVC.Controllers
{
    public class EmployeeController : Controller
    {
        //private NorthwindDbContext _dbcontext;
        //public EmployeeController(NorthwindDbContext northwindDbContext)
        //{
        //    _dbcontext = northwindDbContext;
        //}

        //private INorthwindEmployeeRepository _EmployeeRepository;
        //public EmployeeController(INorthwindEmployeeRepository northwindEmployeeRepository)
        //{
        //    _EmployeeRepository = northwindEmployeeRepository;
        //}

        private IGenericRepository<Employee> _dbEmployee;
        public EmployeeController(IGenericRepository<Employee> employeeRepository ) 
        { 
        _dbEmployee = employeeRepository;
        }


        public IActionResult Index()
        {
            //var q = _dbcontext.Employees;
            //return View(_EmployeeRepository.GetAll());
            return View(_dbEmployee.GetAll());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            //_dbcontext.Employees.Add(employee);
            //_dbcontext.SaveChanges();

            //_EmployeeRepository.Add(employee);
            //_EmployeeRepository.SavaChanges();

            _dbEmployee.Add(employee);
            _dbEmployee.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
