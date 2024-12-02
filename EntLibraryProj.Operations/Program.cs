using EntLibraryProj.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using EntLibraryProj.Entities;
//Modified by Ian

var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("SQLiteConn");// ?? throw new InvalidOperationException("Connection string 'LibraryDbContext' not found.");

builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConn")));
builder.Services.AddDefaultIdentity<LibraryUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LibraryDbContext>();

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ILibraryService, LibraryRepo>();
builder.Services.AddScoped<ICategoryServices, CategoryRepository>();
builder.Services.AddScoped<IUserService, UserRepo>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseMigrationsEndPoint();
//}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
