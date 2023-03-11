using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FoodApp.BLL.Implementation;
using FoodApp.BLL.Interface;
using FoodApp.DAL.Entities;
using FoodApp.DAL.Repository;
using FoodApp.DAL.Seeds;


namespace FoodApp.MVC
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<FoodAppDbContext>(opts =>
            {

                var defaultConnString = builder.Configuration.GetSection("ConnectionString")["DefaultConnString"];

                opts.UseSqlServer(defaultConnString);

            });

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork<FoodAppDbContext>>();
            //builder.Services.AddScoped<IUserService, UserService>();//todo: show other life-cycles
            builder.Services.AddScoped<IMenuOperations, MenuOperations>();//todo: show other life-cycles
            builder.Services.AddAutoMapper(Assembly.Load("FoodApp.BLL"));
           


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

            await SeedData.EnsurePopulatedAsync(app);

            await app.RunAsync();
        }
    }
}