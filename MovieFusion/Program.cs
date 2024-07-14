using Microsoft.EntityFrameworkCore;
using MovieFusion.Models;

namespace MovieFusion
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<MovieFusionContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("MovieFusionContext")));

            // Add session services
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            // Enable session middleware
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "about",
                pattern: "{controller=Home}/{action=About}/{id?}");

            app.MapControllerRoute(
                name: "contact",
                pattern: "{controller=Home}/{action=Contact}/{id?}");

            app.MapControllerRoute(
                name: "signup",
                pattern: "{controller=Home}/{action=SignUp}/{id?}");

            app.MapControllerRoute(
                name: "login",
                pattern: "{controller=Home}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
