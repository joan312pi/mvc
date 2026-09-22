using LabMVC.Models.NorthwindDbContext;
using Microsoft.EntityFrameworkCore;

namespace WebAPIlab.Data
{
    public class NorthwindDbContext:DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Employee> Employees { get; set; }

    }
}
