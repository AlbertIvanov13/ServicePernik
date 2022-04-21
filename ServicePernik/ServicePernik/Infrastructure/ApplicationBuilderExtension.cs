using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ServicePernik.Data;
using ServicePernik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;
            var data = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedsStatusReservation(data);
           // var servicesCategories = serviceScope.ServiceProvider;
          //  var dataCategories = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            
            SeedsStatusReservation(data);
            await RoleSeeder(services);
            await SeedAdministrator(services);
            SeedsRepairCategories(data);

            return app;
        }

        private static void SeedsStatusReservation(ApplicationDbContext data)
        {
            if (data.StatusReservations.Any())
            {
                return;
            }
            data.StatusReservations.AddRange(new[]
            {
                new StatusReservation {Name="Waiting"},
                new StatusReservation {Name="InProccess"},
                new StatusReservation {Name="Done"},
                new StatusReservation {Name="Denied"},
               
            });
            data.SaveChanges();
        }

        private static void SeedsRepairCategories(ApplicationDbContext data)
        {
            if (data.RepairCategories.Any())
            {
                return;
            }
            data.RepairCategories.AddRange(new[]
            {
                new RepairCategory {Name="Diagnostic"},
                new RepairCategory {Name="Installation"},
                new RepairCategory {Name="Profilactica"},
                
            });
            data.SaveChanges();
        }
        private static async Task RoleSeeder(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            string[] roleNames = { "Administrator", "Client", "Employee"};

            IdentityResult roleResult;

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);

                if (!roleExist)
                {
                    roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }


        private static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ServiceUser>>();

            if (await userManager.FindByNameAsync("admin") == null)
            {
                ServiceUser user = new ServiceUser();
                user.UserName = "admin";
                user.Email = "admin@admin.com";
                user.PhoneNumber = "00000000";

                var result = await userManager.CreateAsync
                (user, "123!@#qweQWE");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }

    }
}
