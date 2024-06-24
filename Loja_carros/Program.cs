using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Loja_carros.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Loja_carrosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Loja_carrosContext") ?? throw new InvalidOperationException("Connection string 'Loja_carrosContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
