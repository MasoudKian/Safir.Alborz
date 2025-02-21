using Application.Contracts.Interfaces.APIs;
using Application.Contracts.Interfaces.IGeneric;
using Application.Contracts.Interfaces.Repositories;
using Application.Contracts.Interfaces.Repositories.HumanResources;
using Application.Contracts.Interfaces.UserServices;
using Application.Contracts.InterfaceServices.Address;
using Application.Contracts.InterfaceServices.HumanResources;
using Application.Contracts.InterfaceServices.MSCRM;
using Application.Profiles;
using Identity.DbContext;
using Identity.PersistenceServices.Services;
using Identity.PersistenceServices.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Services.ImplementationServices.Address;
using Persistence.Services.ImplementationServices.HumanResources;
using Persistence.Services.ImplementationServices.MSCRM;
using Persistence.Services.Repositories;
using Persistence.Services.Repositories.HumanResources;
using Persistence.Services.Repository;
using System.Reflection;

namespace Persistence.Services
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices
            (this IServiceCollection services, IConfiguration configuration)
        {


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

            services.AddScoped<IPositionRepository, PositionRepository>();
            services.AddScoped<IPositionService, PositionService>();


            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAddressService, AddressService>();

            services.AddScoped<IMSCRMRepository, MSCRMRepository>();
            services.AddScoped<IMSCRMService, MSCRMService>();


            services.AddAutoMapper(typeof(MappingProfile));
            //services.AddAutoMapper(Assembly.GetExecutingAssembly());
            //services.AddMediatR(Assembly.GetExecutingAssembly());



            services.AddHttpClient<AuthIdentityService>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7156/"); // آدرس API خود را اینجا وارد کنید
            });

            return services;
        }
    }
}
