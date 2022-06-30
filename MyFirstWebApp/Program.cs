using MyFirstWebApp.Services;
using static MyFirstWebApp.Services.Contracts.IjokeServise;
using static MyFirstWebApp.Services.Contracts.ILoggerService;
using static MyFirstWebApp.Services.LoggerService;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices((host, services) =>
{
    services.AddSingleton<ILoggerServise, LoggerServise>();
    services.AddTransient<IJokeServise, JokeServise>();
});


// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
