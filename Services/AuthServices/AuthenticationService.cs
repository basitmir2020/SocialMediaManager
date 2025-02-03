namespace SocialMediaAutoPosterApp.Services.AuthServices;

public class AuthenticationService : IAuthenticationService
{
    public Task<bool> LoginAsync(string? username, string? password)
    {
        if (username == "admin" && password == "password") // Dummy validation
        {
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}