using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using mvcWebAssesment.Areas.Identity.Data;
using mvcWebAssesment.Data;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("mvcWebAssesmentDBContextConnection") ?? throw new InvalidOperationException("Connection string 'mvcWebAssesmentDBContextConnection' not found.");

builder.Services.AddDbContext<mvcWebAssesmentDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<mvcWebAssesmentDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.AddDbContext<PetsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PetsContext") ?? throw new InvalidOperationException("Connection string 'PetsContext' not found.")));

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


app.MapRazorPages();
app.Run();
