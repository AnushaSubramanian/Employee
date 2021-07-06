using EmployeeCompany.DB.SeedData;
using EmployeeCompany.Model;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCompany.DB
{
    public class DataContext : DbContext
    {
        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ImportCompanyData();
        }
    }
}
