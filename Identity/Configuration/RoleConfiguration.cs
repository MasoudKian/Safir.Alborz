using Identity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Identity.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationRole> builder)
        {
            builder.HasData(
                new ApplicationRole
                {
                    Id = "cb275765-1cac-4652-a03f-f8871dd575d1",
                    Name = "PowerAdmin",
                    NormalizedName = "POWERADMIN",
                    Description = "Responsible for the entire site",
                },
                new ApplicationRole
                {
                    Id = "717f2382-d718-455d-a238-47df91977d71",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    Description = "Just admin ... ",
                },
                new ApplicationRole
                {
                    Id = "4d3dcfaf-9228-41d4-947e-b267194a5356",
                    Name = "User",
                    NormalizedName = "USER",
                    Description = "User site ... ",
                }
            );
        }
    }
}
