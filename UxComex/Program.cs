using dotenv.net;
using UxComex.Source.Domain.Interfaces.Repositories;
using UxComex.Source.Domain.Interfaces.Services;
using UxComex.Source.Infraestructure.Repositories;
using UxComex.Source.Infraestructure.Services;

var builder = WebApplication.CreateBuilder(args);

DotEnv.Load();

builder.Configuration.AddJsonFile("appsettings.json");

var connectionString = Environment.GetEnvironmentVariable("MY_CONNECTION_STRING") ?? builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddScoped<IClientRepository>(x =>
    new ClientRepository(connectionString));
builder.Services.AddScoped<IAddressRepository>(x =>
    new AddressRepository(connectionString));

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IAddressService, AddressService>();


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
