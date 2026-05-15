using Microsoft.EntityFrameworkCore;
using StudentRepositoryDemo.Data;
using StudentRepositoryDemo.Repository;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IStudentRepository, StudentRepository>();

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();