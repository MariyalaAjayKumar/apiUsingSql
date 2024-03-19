using EmployeesData.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesData.Data
{
    public class EmployeedbContext : DbContext
    {
        public EmployeedbContext(DbContextOptions<EmployeedbContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}
