using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Models.Context
{
    public class EmployeeDBContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options) : base(options) { }
    }
}
