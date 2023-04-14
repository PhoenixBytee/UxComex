using Microsoft.Extensions.Configuration;
using UxComex.Source.Domain.Interfaces.Repositories;
using UxComex.Source.Domain.Interfaces.Services;
using UxComex.Source.Infraestructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IClientRepository>(x =>
    new ClientRepository(connectionString));
builder.Services.AddScoped<IAddressRepository>(x =>
    new AddressRepository(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Index}/{id?}");

app.Run();
