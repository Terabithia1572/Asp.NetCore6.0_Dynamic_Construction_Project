//using DataAccessLayer.Concrete;
//using DNTCaptcha.Core;
//using EntityLayer.Concrete;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc.Authorization;
//using Microsoft.EntityFrameworkCore;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<Context>();

//builder.Services.AddIdentity<AppUser, AppRole>(options =>
//{
//    options.Password.RequireUppercase = false;
//    options.Password.RequireNonAlphanumeric = false;
//    options.Password.RequireLowercase = false;
//})
//.AddEntityFrameworkStores<Context>()
//.AddDefaultTokenProviders();
//// Add services to the container.
//builder.Services.AddControllersWithViews();
//builder.Services.AddDNTCaptcha(options =>
//    options.UseCookieStorageProvider()
//           .ShowThousandsSeparators(false)
//           .WithEncryptionKey("123456"));
//builder.Services.AddSession();
//var policy = new AuthorizationPolicyBuilder()
//    .RequireAuthenticatedUser()
//    .Build();

//// MVC'yi ekleyin ve authorization filtresini ekleyin
//builder.Services.AddControllersWithViews(config => {
//    config.Filters.Add(new AuthorizeFilter(policy));
//});
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Login/Index";
//    });



//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Product/Index");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();
//app.UseDefaultFiles();
//app.UseRouting();

//app.UseSession();
//app.UseAuthentication();  // Eðer authentication kullanýyorsanýz
//app.UseAuthorization();   // Eðer authorization kullanýyorsanýz
//app.UseEndpoints(endpoints => {
//    endpoints.MapDefaultControllerRoute();
//});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Product}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Product}/{action=Index}/{id?}");
//});

//app.Run();
using DataAccessLayer.Concrete;
using DNTCaptcha.Core;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Context>();

builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
})
.AddEntityFrameworkStores<Context>()
.AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDNTCaptcha(options =>
    options.UseCookieStorageProvider()
           .ShowThousandsSeparators(false)
           .WithEncryptionKey("123456"));
builder.Services.AddSession();

var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();

// MVC'yi ekleyin ve authorization filtresini ekleyin
builder.Services.AddControllersWithViews(config => {
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Product/Index");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();  // Eðer authentication kullanýyorsanýz
app.UseAuthorization();   // Eðer authorization kullanýyorsanýz

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
