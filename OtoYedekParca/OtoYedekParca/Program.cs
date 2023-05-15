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
using Newtonsoft.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddNewtonsoftJson(options =>
    options.SerializerSettings.ContractResolver = new DefaultContractResolver()
);

builder.Services.AddRazorPages();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});



builder.Services.AddSignalR();
builder.Services.AddCors();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddIdentity<User , IdentityRole>(x => 
{
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequiredLength = 5;
    x.Password.RequireLowercase = false;
    x.Password.RequireDigit = false;
    x.Password.RequireUppercase = false;
    x.User.RequireUniqueEmail = true;
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
      name: "KayitOl",
      pattern: "KayitOl",
      defaults: new { controller = "Auth", action = "Register" }
  );
     endpoints.MapControllerRoute(
      name: "GirisYap",
      pattern: "GirisYap",
      defaults: new { controller = "Auth", action = "Login" }
  );
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
        name: "Anasayfa",
        pattern: "Anasayfa",
        defaults: new { controller = "Home", action = "Index" }
    );
     endpoints.MapControllerRoute(
        name: "hakkimizda",
        pattern: "hakkimizda",
        defaults: new { controller = "Home", action = "Hakkimizda" }
    );
     endpoints.MapControllerRoute(
        name: "MarkaTanimlama",
        pattern: "MarkaTanimlama",
        defaults: new { controller = "Admin", action = "Marka" }
    );
     endpoints.MapControllerRoute(
        name: "TipTanimlama",
        pattern: "TipTanimlama",
        defaults: new { controller = "Admin", action = "Tip" }
    );
     endpoints.MapControllerRoute(
        name: "ModelTanimlama",
        pattern: "ModelTanimlama",
        defaults: new { controller = "Admin", action = "Model" }
    );
     endpoints.MapControllerRoute(
        name: "UrunTanimlama",
        pattern: "UrunTanimlama",
        defaults: new { controller = "Admin", action = "Urun" }
    );

});

app.Run();
