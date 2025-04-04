using Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configuration
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    UserId = "80b54bba-8dca-476f-a4ee-f6b48681f8d6", // شناسه یکتا برای کاربر
                    
                    RoleId = "4d30875f-1ec8-455e-bffa-7c5f958db186",
                },
                new IdentityUserRole<string>
                {
                    UserId = "80b54bba-8dca-476f-a4ee-f6b48681f8d6", // شناسه یکتا برای کاربر

                    RoleId = "4d3dcfaf-9228-41d4-947e-b267194a5355",
                });
        }
    }
}
