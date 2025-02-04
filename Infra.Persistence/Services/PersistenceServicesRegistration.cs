using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;

namespace Persistence.Services
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SafirDbContext>(options =>
            {
                options.UseSqlServer(configuration
                    .GetConnectionString("SAKConnectionString"));
            });

            //services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
