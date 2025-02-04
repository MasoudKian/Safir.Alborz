using Domain.Entities.HumanResources.EmployeeManagement;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Context
{
    public class SafirDbContext : DbContext
    {
        public SafirDbContext(DbContextOptions<SafirDbContext> options) : base(options)
        {

        }
        #region Entities

        public DbSet<Employee> Employees { get; set; }

        #endregion
    }
}
