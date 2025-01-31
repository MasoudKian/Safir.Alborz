using Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var passHasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser()
                {
                    Id = "745cfc52-13b9-4a4c-baad-f4b11536c49e", // شناسه یکتا برای کاربر
                    UserName = "PowerAdmin", // ایمیل کاربر
                    NormalizedUserName = "POWERADMIN",
                    Email = "masoudkiannejad@gmail.com", // ایمیل کاربر
                    NormalizedEmail = "MASOUDKIANNEJAD@GMAIL.COM",
                    EmailConfirmed = true, // تأیید ایمیل
                    FirstName = "Power", // نام
                    LastName = "Admin", // نام خانوادگی
                    PasswordHash = passHasher.HashPassword(null,"P@wer_Admin^123"),
                    CreatedDate = DateTime.Now, // تاریخ ایجاد
                    LastUpdateDate = DateTime.Now, // تاریخ به‌روزرسانی
                    Code = "1",
                    
                });
        }
    }
}
