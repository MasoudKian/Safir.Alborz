using Application.Contracts.Interfaces.APIs;
using Application.Contracts.Interfaces.UserServices;
using Application.Models.AuthenticationIdentity;
using Identity.DbContext;
using Identity.Model;
using Identity.PersistenceServices.Services;
using Identity.PersistenceServices.Services.Implementation;
using Identity.PersistenceServices.Services.Interfaces;
using Identity.UtilsIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Identity.PersistenceServices
{
    public static class IdentityServicesRegistration
    {

        //#region With JWT

        //public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services
        //    , IConfiguration configuration)
        //{

        //    #region JWT Setting

        //    services.Configure<JWTSetting>(configuration.GetSection("JwtSettings"));

        //    #endregion

        //    #region Config Connection String


        //    services.AddDbContext<SafirIdentityDbContext>(option =>
        //    {
        //        option.UseSqlServer(configuration.GetConnectionString("SAKIdentityConnectionString"),
        //            m => m.MigrationsAssembly(typeof(SafirIdentityDbContext).Assembly.FullName));

        //    });
        //    services.AddIdentity<ApplicationUser, ApplicationRole>()
        //        .AddEntityFrameworkStores<SafirIdentityDbContext>().AddDefaultTokenProviders();

        //    services.AddAuthentication(options =>
        //    {
        //        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        //        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //    }).AddJwtBearer(o =>
        //    {
        //        o.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            ValidateIssuerSigningKey = true,
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ClockSkew = TimeSpan.Zero,
        //            ValidIssuer = configuration["JwtSettings:Issuer"],
        //            ValidAudience = configuration["JwtSettings:Audience"],
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
        //        };
        //    });

        //    #endregion

        //    services.AddTransient<IAuthService, AuthService>();
        //    services.AddScoped<IUserService, UserService>();

        //    return services;
        //}

        //#endregion


        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Config Connection String

            services.AddDbContext<SafirIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SAKIdentityConnectionString"),
                    m => m.MigrationsAssembly(typeof(SafirIdentityDbContext).Assembly.FullName));
            });

            // پیکربندی Identity
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;

                // تنظیمات قفل شدن حساب
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;
            })
                .AddEntityFrameworkStores<SafirIdentityDbContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<CustomIdentityErrorDescriber>(); // استفاده از کلاس سفارشی;

            #endregion

            // تنظیمات قفل شدن حساب کاربری
            services.Configure<IdentityOptions>(options =>
            {
                // تنظیمات قفل حساب کاربری
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(60); // مدت زمان قفل شدن (60 دقیقه)
                options.Lockout.MaxFailedAccessAttempts = 3; // تعداد تلاش‌های ناموفق قبل از قفل شدن
                options.Lockout.AllowedForNewUsers = true; // فعال بودن قفل شدن برای کاربران جدید
            });

            // ثبت سرویس‌های مربوط به احراز هویت
            //services.AddTransient<IAuthService, AuthService>();
            services.AddScoped<IAuthIdentityService, AuthIdentityService>();

            
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }

    }
}
