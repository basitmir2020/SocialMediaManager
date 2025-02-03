using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components;
using SocialMediaAutoPosterApp.Services.AuthServices;

namespace SocialMediaAutoPosterApp.Components.Pages.Auth.AuthLogin;

public partial class AuthLogin : ComponentBase
{
    [Inject] private NavigationManager? Navigation { get; set; }
    [Inject] private IAuthenticationService? AuthenticationService { get; set; }
    
    private readonly LoginModel _loginModel = new()
    {
        Username = null,
        Password = null
    };
    private string _errorMessage = string.Empty;

    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public required string Password { get; set; }
    }

    private async Task HandleLogin()
    {
        var result = await AuthenticationService?.LoginAsync(_loginModel.Username, _loginModel.Password)!;
        if (result)
        {
            Navigation?.NavigateTo("/dashboard"); // Redirect to the dashboard after successful login
        }
        else
        {
            _errorMessage = "Invalid username or password";
        }
    }
}