using Application.Contracts.Interfaces.APIs;
using Application.Contracts.Interfaces.IGeneric;
using Application.Contracts.Interfaces.Repositories;
using Application.Contracts.Interfaces.UserServices;
using Application.Contracts.InterfaceServices;
using Identity.DbContext;
using Identity.PersistenceServices.Services;
using Identity.PersistenceServices.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Services.ImplementationServices;
using Persistence.Services.Repositories;
using Persistence.Services.Repository;
using System.Reflection;

namespace Persistence.Services
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddDbContext<SafirDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SAKConnectionString"),
                    m => m.MigrationsAssembly(typeof(SafirDbContext).Assembly.FullName));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            
            
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDepartmentService, DepartmentService>();





            


            services.AddHttpClient<AuthIdentityService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7156/"); // آدرس API خود را اینجا وارد کنید
            });

            return services;
        }
    }
}
