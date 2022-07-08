using Beers.Core.Interfaces.AppServices.BeerServices;
using Beers.Core.Interfaces.DataServices;
using Beers.Application.AppServices;
using Beers.Application.AppServices.BrandService;
using IntoAsp.DataAccess.BeerServices;
using Microsoft.EntityFrameworkCore;
using Beers.DataAccess;
using Beers.DataAccess.BeerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IBeerAppService, BeerAppService>();
builder.Services.AddScoped<IBrandAppService, BrandAppService>();

builder.Services.AddScoped<IBeerDataService, BeerDataService>();
builder.Services.AddScoped<IBrandDataService, BrandDataService>();

builder.Services.AddDbContext<IntroAspContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IntroAsp"));
});

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
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
