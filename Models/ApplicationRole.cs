using Microsoft.AspNetCore.Identity;

namespace SocialMediaAutoPosterApp.Models;

public class ApplicationRole: IdentityRole
{
    // A flag to indicate if the role is active.
    public bool IsActive { get; set; } = true;
    
    // The date and time when the role was created.
    public required DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    // The user (by identifier) who created the role.
    public required string CreatedBy { get; set; }

    // The date and time when the role was last updated.
    public DateTime? UpdatedOn { get; set; } = DateTime.UtcNow;

    // The user (by identifier) who last updated the role.
    public string? UpdatedBy { get; set; }
}