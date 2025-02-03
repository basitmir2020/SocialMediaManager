namespace SocialMediaAutoPosterApp.Services.AuthServices;

public interface IAuthenticationService
{
    Task<bool> LoginAsync(string? username, string? password);
}