using Microsoft.EntityFrameworkCore;
using try2.DAL;
using try2.DAL.Interfaces;
using try2.DAL.Repositories;
using try2.Domain.Entities;
using try2.Domain.Models.Entities;
using try2.Services;
using try2.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

/*builder.Services.AddDbContext<AccountDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));*/


builder.Services.AddDbContext<AccountDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("POSTGRESQL")));

builder.Services.AddTransient<IHashService, HashService>();
builder.Services.AddTransient<IJwtService, JwtService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IRepository<Profile>, ProfileRepository>();

builder.Services.AddTransient<IRepository<User>, UserRepository>();


var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

//app.UseResponseCaching();


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
