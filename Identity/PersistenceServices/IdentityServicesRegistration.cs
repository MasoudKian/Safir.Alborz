using Identity.DbContext;
using Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.PersistenceServices
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services
            , IConfiguration configuration)
        {
            #region Config Connection String

            services.AddDbContext<SafirIdentityDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("SAKIdentityConnectionString"),
                    m => m.MigrationsAssembly(typeof(SafirIdentityDbContext).Assembly.FullName));
                
            });
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<SafirIdentityDbContext>().AddDefaultTokenProviders();

            #endregion


            return services;
        }
    }
}
