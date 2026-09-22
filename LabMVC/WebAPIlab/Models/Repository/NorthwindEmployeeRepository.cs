using LabMVC.Models.NorthwindDbContext;
using LabMVC.Models.Repository.IRepository;

namespace LabMVC.Models.Repository
{
    public class NorthwindEmployeeRepository : INorthwindEmployeeRepository
    {

        private WebAPIlab.Data.NorthwindDbContext _dbcontext;
        public NorthwindEmployeeRepository(WebAPIlab.Data.NorthwindDbContext northwindDbContext)
        {
            _dbcontext = northwindDbContext;
        }

        public void Add(Employee employee)
        {
            _dbcontext.Employees.Add(employee);
        }

        public void Delete(int id)
        {
            _dbcontext.Remove(new Employee { EmployeeID= id });
        }

        public IEnumerable<Employee> GetAll()
        {
            return _dbcontext.Employees;
        }

        public Employee? GetById(int id)
        {
            return _dbcontext.Employees.Find(id);
        }

        public void SavaChanges()
        {
            _dbcontext.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _dbcontext.Update(employee);
        }
    }
}
