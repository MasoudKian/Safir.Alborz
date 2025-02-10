using Application.Contracts.Interfaces.APIs;
using Identity.PersistenceServices;
using Microsoft.Extensions.Options;
using Persistence.Services;
using WEB.Models.Api;
using WEB.Services;
using WEB.Services.IdentityAPIs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Configurations

builder.Services.ConfigureIdentityServices(builder.Configuration);
builder.Services.ConfigurePersistenceServices(builder.Configuration);

#endregion

builder.Services.AddScoped<IAuthIdentityAPIService, AuthIdentityAPIService>();

// For API
//builder.Services.AddHttpClient();
builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection("ApiSettings"));
builder.Services.AddHttpClient<AuthIdentityAPIService>(options =>
{
    var serviceProvider = builder.Services.BuildServiceProvider();
    var apiSettings = serviceProvider.GetRequiredService<IOptions<ApiSettings>>().Value;
    options.BaseAddress = new Uri(apiSettings.BaseUrl);
});
//builder.Services.AddScoped<AuthWebServices, AuthWebServices>();

// For API

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=AdminHome}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
