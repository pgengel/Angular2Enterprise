using System.Data.Entity;
using Angular2Enterprise.Database.Models;

namespace Angular2Enterprise.Database.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext() : base("Default")
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
