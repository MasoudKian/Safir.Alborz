using Domain.Entities.Address;
using Domain.Entities.HumanResources.EmployeeManagement;
using Domain.Entities.MSCRM;
using Domain.Entities.ProductsCategories;
using Domain.Entities.Site.SiteMenu;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Persistence.Context
{
    public class SafirDbContext : DbContext
    {
        public SafirDbContext(DbContextOptions<SafirDbContext> options) : base(options)
        {

        }
        #region Entities

        #region Human Resources

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }

        #endregion

        #region MSCRM

        public DbSet<Clue> Clues { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Marketer> Marketers { get; set; }

        #endregion

        #region Address

        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Region> Regions { get; set; }

        #endregion

        #region Site

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuAccess> MenuAccesses { get; set; }

        #endregion

        #region Products

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }

        #endregion

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Human Resources

            // تنظیم رابطه Department -> Positions
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Positions)
                .WithOne(p => p.Department)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // تنظیم رابطه Department -> Employees
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees)
                .WithOne(e => e.Department)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            // تنظیم رابطه Position -> Employees
            modelBuilder.Entity<Position>()
                .HasMany(p => p.Employees)
                .WithOne(e => e.Position)
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion


            #region Product

            modelBuilder.Entity<CategoryProduct>()
                .HasKey(cp => new { cp.CategoryId, cp.ProductId });

            modelBuilder.Entity<CategoryProduct>()
                .HasOne(cp => cp.Category)
                .WithMany(c => c.CategoryProducts)
                .HasForeignKey(cp => cp.CategoryId);

            modelBuilder.Entity<CategoryProduct>()
                .HasOne(cp => cp.Product)
                .WithMany(p => p.CategoryProducts)
                .HasForeignKey(cp => cp.ProductId);

            #endregion

        }
    }
}
