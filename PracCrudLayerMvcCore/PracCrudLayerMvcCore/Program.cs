using Microsoft.EntityFrameworkCore;
using PracCrudLayerMvcCore.Business;
using PracCrudLayerMvcCore.DAL;
using PracCrudLayerMvcCore.DAL.Models;
using PracCrudLayerMvcCore.Logger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

string loggingFolderPath = builder.Configuration.GetValue<string>("LoggingFolderPath");

builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IDataAccess, DataAccess>();
builder.Services.AddSingleton<PracCrudLayerMvcCore.Logger.ILogger>(new Logger(loggingFolderPath));

builder.Services.AddDbContext<PracticeContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DBCS")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
