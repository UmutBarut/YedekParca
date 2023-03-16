using Autofac.Extensions.DependencyInjection;
using Autofac;
using OtoYedekParca.Core.Utilities.IoC;
using OtoYedekParca.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using OtoYedekParca.Business.Abstracts;
using OtoYedekParca.Business.Concrete;
using OtoYedekParca.Business.DependencyResolvers.Autofac;
using OtoYedekParca.Dataaccess.Concrete.Contexts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});


builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddIdentity<User , IdentityRole>(x => 
{
x.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/GirisYap";
    options.Cookie.Name = "auth_cookie";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );

});

app.Run();
