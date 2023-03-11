using FoodApp.DAL.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodApp.DAL.Seeds
{
    public class SeedData
    {
        public static async Task EnsurePopulatedAsync(IApplicationBuilder app)
        {
            FoodAppDbContext context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<FoodAppDbContext>();

            if (!await context.Admins.AnyAsync())
            {
                await context.Admins.AddRangeAsync(GetAdmins());
                await context.SaveChangesAsync();

            }


        }

        private static IEnumerable<Admin> GetAdmins()
        {
            return new List<Admin>()
            {
                new Admin()
                {
                    UserName = "Chinenye",
                    Password = "$Chinenye1234",
                },
                new Admin()
                {
                    UserName = "Rose",
                    Password = "$Rose1234",
                }
            };
        }
    }
}
