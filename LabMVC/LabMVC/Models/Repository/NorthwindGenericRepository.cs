using LabMVC.Models.NorthwindDbContext;
using LabMVC.Models.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace LabMVC.Models.Repository
{
    public class NorthwindGenericRepository<Table> : IGenericRepository<Table> where Table : class
    {
        private NorthwindDbContext.NorthwindDbContext _dbContext;
        private DbSet<Table> _dbSet;

        public NorthwindGenericRepository(NorthwindDbContext.NorthwindDbContext northwindDbContext)
        {
            _dbContext = northwindDbContext;
            _dbSet = _dbContext.Set<Table>();
          }


        public void Add(Table entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(Table entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<Table> GetAll()
        {
            return _dbSet;
        }

        public Table? GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Table entity)
        {
            _dbSet.Update(entity);
        }
    }
}
