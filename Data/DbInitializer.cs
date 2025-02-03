using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMediaAutoPosterApp.Models;

namespace SocialMediaAutoPosterApp.Data;

public static class DbInitializer
{
    public static async Task SeedData(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Apply migrations
            await context.Database.MigrateAsync();

            // Seed Roles
            if (!await roleManager.Roles.AnyAsync())
            {
                var roles = new[]
                {
                    new ApplicationRole
                    {
                        Name = "Admin", NormalizedName = "ADMIN", CreatedOn = DateTime.UtcNow, CreatedBy = "System",
                        IsActive = true
                    },
                    new ApplicationRole
                    {
                        Name = "Agency", NormalizedName = "USER", CreatedOn = DateTime.UtcNow, CreatedBy = "System",
                        IsActive = true
                    },
                    new ApplicationRole
                    {
                        Name = "Client", NormalizedName = "USER", CreatedOn = DateTime.UtcNow, CreatedBy = "System",
                        IsActive = true
                    },
                    new ApplicationRole
                    {
                        Name = "User", NormalizedName = "USER", CreatedOn = DateTime.UtcNow, CreatedBy = "System",
                        IsActive = true
                    }
                };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(role);
                }
            }

            // Seed Admin User
            if (!await userManager.Users.AnyAsync())
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    EmailConfirmed = true,
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System",
                    IsActive = true
                };

                var result = await userManager.CreateAsync(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // Seed Default Agency
            if (!await context.Agencies.AnyAsync())
            {
                await context.Agencies.AddAsync(new Agency
                {
                    Id = Guid.NewGuid(),
                    Name = "Default Agency",
                    CreatedOn = DateTime.UtcNow,
                    CreatedBy = "System",
                    IsActive = true
                });

                await context.SaveChangesAsync();
            }
        }
    }
}