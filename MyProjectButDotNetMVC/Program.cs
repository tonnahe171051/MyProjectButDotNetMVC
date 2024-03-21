using MyProjectButDotNetMVC.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using MyProjectButDotNetMVC.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FstoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FStore")));
builder.Services.AddScoped(typeof(FstoreContext));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();

