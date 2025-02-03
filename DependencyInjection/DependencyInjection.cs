using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using SocialMediaAutoPosterApp.Data;
using SocialMediaAutoPosterApp.Models;
using SocialMediaAutoPosterApp.Services.AuthServices;

namespace SocialMediaAutoPosterApp.DependencyInjection;

public static class DependencyInjection
{
    // Register all services here
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMudServices();
        services.AddSingleton<IAuthenticationService, AuthenticationService>();
    }

    public static IServiceCollection AddApplicationDataServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        // Register the ApplicationDbContext using SQL Server and a connection string from configuration.
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        // Register ASP.NET Core Identity with the ApplicationDbContext.
        services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = true;
                options.Lockout.MaxFailedAccessAttempts = 10;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        return services;
    }
}