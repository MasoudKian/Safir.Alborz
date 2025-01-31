using Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.DbContext
{
    public class SafirIdentityDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public SafirIdentityDbContext(DbContextOptions<SafirIdentityDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // افزودن نقش PowerAdmin
            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = "cb275765-1cac-4652-a03f-f8871dd575d1",
                    Name = "PowerAdmin",
                    NormalizedName = "POWERADMIN",
                    Description = "Responsible for the entire site",
                }
            );

            //// افزودن کاربر PowerAdmin
            //var powerAdminUser = new ApplicationUser
            //{
            //    Id = "d7e42a8d-7c66-47c6-b99f-ea55f71f4b64", // شناسه یکتا برای کاربر
            //    UserName = "PowerAdmin", // ایمیل کاربر
            //    NormalizedUserName = "POWERADMIN",
            //    Email = "masoudkiannejad@gmail.com", // ایمیل کاربر
            //    NormalizedEmail = "MASOUDKIANNEJAD@GMAIL.COM",
            //    EmailConfirmed = true, // تأیید ایمیل
            //    PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, "P@weR_AdMin^123!"), // رمز عبور (توجه داشته باشید که باید یک رمز عبور امن استفاده کنید)
            //    FirstName = "Power", // نام
            //    LastName = "Admin", // نام خانوادگی
            //    //CreatedDate = DateTime.Now, // تاریخ ایجاد
            //    //LastUpdateDate = DateTime.Now, // تاریخ به‌روزرسانی
            //};

            //builder.Entity<ApplicationUser>().HasData(powerAdminUser);

        }
    }
}
