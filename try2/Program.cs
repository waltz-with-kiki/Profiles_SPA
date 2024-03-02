using Microsoft.EntityFrameworkCore;
using try2.DAL;
using try2.DAL.Interfaces;
using try2.DAL.Repositories;
using try2.Domain.Entities;
using try2.Domain.Models.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

/*builder.Services.AddDbContext<AccountDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));*/


builder.Services.AddDbContext<AccountDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("POSTGRESQL")));

builder.Services.AddTransient<IRepository<Profile>, DbRepository<Profile>>();

builder.Services.AddTransient<IRepository<User>, DbRepository<User>>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();



app.UseCors(
    x =>
    {
        x.WithHeaders().AllowAnyHeader();
        x.WithOrigins("https://localhost:44449");
        x.WithMethods().AllowAnyMethod();
    }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
