
using Microsoft.EntityFrameworkCore;
using Repositories.Database;
using Repositories.Interfaces;
using Repositories.Repositories;

namespace ZolotukhinShop;

public class Program
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddTransient<IProductRepository, ProductRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddDistributedMemoryCache();
        services.AddSession();
    }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        ConfigureServices(builder.Services);

        builder.Services.AddDbContext<DatabaseContext>(
            options => options.UseLazyLoadingProxies().UseSqlite(
                builder.Configuration.GetConnectionString("SQLite")));

        var app = builder.Build();
        app.UseSession();
        
        // Apply migrations at startup and initialize the database with some data (if not exists)
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
            dbContext.Database.Migrate();
            DatabaseInitializer.Initialize(dbContext);
        }

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
            "default",
            "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}