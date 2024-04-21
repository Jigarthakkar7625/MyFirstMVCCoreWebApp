using Microsoft.EntityFrameworkCore;
using MyFirstMVCCoreWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

/// 3>> SQL server, Connection string >> DB context
/// 

// Read connection string from appsetting.json file
var connString = builder.Configuration.GetConnectionString("DefaultConnection");

// SQL + EF (Context) + Connection String
builder.Services.AddDbContext<AtcgsaWithoutAspnetauthContext>(options => options.UseSqlServer(connString));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//____________________________________________________

app.UseHttpsRedirection();
app.UseStaticFiles();

// Midleware
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();

// Program.cs
// Starup.cs

/// Database first >> Using scaffold
/// Code first
/// Model First (NO need to do)
