namespace LabMVC.Models.Repository.IRepository
{
    public interface IGenericRepository<Table> where Table : class
    {
        Table? GetById(object id);

        IEnumerable<Table> GetAll();

        void Add(Table entity);

        void Update(Table entity);
        void Delete(Table entity);

        void SaveChanges();


    }
}
