using Domain.Entities.Address;
using Domain.Entities.HumanResources.EmployeeManagement;
using Domain.Entities.MSCRM;
using Domain.Entities.oredersANDinvoices;
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

        #region Order and Invoice

        public DbSet<Order> Orders { get; set; }

        #endregion

        #endregion


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Region>()
            .HasIndex(r => r.Code)
            .IsUnique();

            modelBuilder.Entity<Employee>()
            .HasIndex(e => e.EmployeeID)
            .IsUnique();  // جلوگیری از مقادیر تکراری

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


            modelBuilder.Entity<Product>()
            .Property(p => p.Price)
            .HasPrecision(18, 2); // دقت و مقیاس را مشخص کنید

            //#region Product

            //modelBuilder.Entity<CategoryProduct>()
            //    .HasKey(cp => new { cp.CategoryId, cp.ProductId });

            //modelBuilder.Entity<CategoryProduct>()
            //    .HasOne(cp => cp.Category)
            //    .WithMany(c => c.CategoryProducts)
            //    .HasForeignKey(cp => cp.CategoryId);

            //modelBuilder.Entity<CategoryProduct>()
            //    .HasOne(cp => cp.Product)
            //    .WithMany(p => p.CategoryProducts)
            //    .HasForeignKey(cp => cp.ProductId);

            //#endregion


            #region Province Seed

            var registeredDate = new DateTime(2025, 2, 18, 0, 0, 0, DateTimeKind.Utc);

            modelBuilder.Entity<Province>().HasData(
                new Province { Id = 1,  Name = "آذربایجان شرقی" , RegisteredDate = registeredDate , RegisteredBy = "Masou With Seed Data" },
                new Province { Id = 2,  Name = "آذربایجان غربی", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province { Id = 3,  Name = "اردبیل", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province { Id = 4,  Name = "اصفهان", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province { Id = 5,  Name = "البرز", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province { Id = 6,  Name = "ایلام", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province { Id = 7,  Name = "بوشهر", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province { Id = 8,  Name = "تهران", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province { Id = 9,  Name = "چهارمحال و بختیاری", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province { Id = 10, Name = "خراسان جنوبی", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province { Id = 11, Name = "خراسان رضوی", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province { Id = 12, Name = "خراسان شمالی", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province { Id = 13, Name = "خوزستان", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 14, Name = "زنجان", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 15, Name = "سمنان", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 16, Name = "سیستان و بلوچستان", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 17, Name = "فارس", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 18, Name = "قزوین", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 19, Name = "قم", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 20, Name = "کردستان", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 21, Name = "کرمان", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 22, Name = "کرمانشاه", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 23, Name = "کهگیلویه و بویراحمد", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 24, Name = "گلستان", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 25, Name = "گیلان", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 26, Name = "لرستان", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 27, Name = "مازندران", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 28, Name = "مرکزی", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 29, Name = "هرمزگان", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 30, Name = "همدان", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new Province {Id = 31, Name = "یزد", RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" }
            );


            // **افزودن مراکز استان‌ها به‌عنوان شهر**
            modelBuilder.Entity<City>().HasData(
                new City { Id = 1,  Name = "تبریز", ProvinceId = 1, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 2,  Name = "ارومیه", ProvinceId = 2, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 3,  Name = "اردبیل", ProvinceId = 3, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 4,  Name = "اصفهان", ProvinceId = 4, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 5,  Name = "کرج", ProvinceId = 5, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 6,  Name = "ایلام", ProvinceId = 6, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 7,  Name = "بوشهر", ProvinceId = 7, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 8,  Name = "تهران", ProvinceId = 8, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 9,  Name = "شهرکرد", ProvinceId = 9, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 10, Name = "بیرجند", ProvinceId = 10, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 11, Name = "مشهد", ProvinceId = 11, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 12, Name = "بجنورد", ProvinceId = 12, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 13, Name = "اهواز", ProvinceId = 13, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 14, Name = "زنجان", ProvinceId = 14, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 15, Name = "سمنان", ProvinceId = 15, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 16, Name = "زاهدان", ProvinceId = 16, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 17, Name = "شیراز", ProvinceId = 17, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 18, Name = "قزوین", ProvinceId = 18, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 19, Name = "قم", ProvinceId = 19, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 20, Name = "سنندج", ProvinceId = 20, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 21, Name = "کرمان", ProvinceId = 21, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 22, Name = "کرمانشاه", ProvinceId = 22, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 23, Name = "یاسوج", ProvinceId = 23, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 24, Name = "گرگان", ProvinceId = 24, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 25, Name = "رشت", ProvinceId = 25, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 26, Name = "خرم‌آباد", ProvinceId = 26, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 27, Name = "ساری", ProvinceId = 27, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 28, Name = "اراک", ProvinceId = 28, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 29, Name = "بندرعباس", ProvinceId = 29, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 30, Name = "همدان", ProvinceId = 30, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" },
                new City { Id = 31, Name = "یزد", ProvinceId = 31, RegisteredDate = registeredDate, RegisteredBy = "Masou With Seed Data" }
            );


            #endregion

        }
    }
}
