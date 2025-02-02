using Application.Contracts.Interfaces.Identity;
using Application.Models.AuthenticationIdentity;
using Identity.DbContext;
using Identity.Model;
using Identity.PersistenceServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Identity.PersistenceServices
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection ConfigureIdentityServices(this IServiceCollection services
            , IConfiguration configuration)
        {

            #region JWT Setting

            services.Configure<JWTSetting>(configuration.GetSection("JwtSettings"));

            #endregion

            #region Config Connection String


            services.AddDbContext<SafirIdentityDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("SAKIdentityConnectionString"),
                    m => m.MigrationsAssembly(typeof(SafirIdentityDbContext).Assembly.FullName));
                
            });
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<SafirIdentityDbContext>().AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                };
            });

            #endregion

            services.AddTransient<IAuthService, AuthService>();


            return services;
        }
    }
}
