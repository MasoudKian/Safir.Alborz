using Application.Contracts.Interfaces.IGeneric;
using Application.Contracts.Interfaces.Repositories;
using Application.Contracts.Interfaces.UserServices;
using Application.Contracts.InterfaceServices;
using Identity.PersistenceServices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Services.ImplementationServices;
using Persistence.Services.Repositories;
using Persistence.Services.Repository;

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

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}
