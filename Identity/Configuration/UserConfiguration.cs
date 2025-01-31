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

            var user = new ApplicationUser()
            {
                Id = "745cfc52-13b9-4a4c-baad-f4b11536c49e", // شناسه یکتا برای کاربر
                UserName = "PowerAdmin",
                NormalizedUserName = "POWERADMIN",
                Email = "masoudkiannejad@gmail.com",
                NormalizedEmail = "MASOUDKIANNEJAD@GMAIL.COM",
                EmailConfirmed = true,
                FirstName = "Power",
                LastName = "Admin",
                CreatedDate = new DateTime(2024, 01, 31, 12, 0, 0), // ✅ مقدار ثابت
                LastUpdateDate = new DateTime(2024, 01, 31, 13, 1, 1), // ✅ مقدار ثابت
                Code = "1",
            };

            // مقداردهی به PasswordHash
            user.PasswordHash = passHasher.HashPassword(user, "P@wer_Admin^123");

            builder.HasData(user);
        }
    }
}
