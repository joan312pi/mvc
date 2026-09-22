using LabMVC.Models.NorthwindDbContext;

namespace LabMVC.Models.Repository.IRepository
{
    public interface INorthwindEmployeeRepository
    {
        IEnumerable<Employee> GetAll();

        Employee? GetById(int id);

        void Add(Employee employee);

        void Update(Employee employee);

        void Delete(int id);

        void SavaChanges();

    }
}
