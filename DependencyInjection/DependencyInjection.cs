using MudBlazor.Services;
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
}