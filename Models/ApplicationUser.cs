using Microsoft.AspNetCore.Identity;

namespace SocialMediaAutoPosterApp.Models;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
    public bool IsActive { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; }
    public DateTime UpdatedOn { get; set; } = DateTime.UtcNow;
    public string? UpdatedBy { get; set; }
}