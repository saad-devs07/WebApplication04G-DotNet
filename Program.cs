using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication04G.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WebApplication04GContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebApplication04GContext") ?? throw new InvalidOperationException("Connection string 'WebApplication04GContext' not found.")));

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
    pattern: "{controller=Students}/{action=Index}/{id?}");

app.Run();
