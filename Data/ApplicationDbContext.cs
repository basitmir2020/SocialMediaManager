using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMediaAutoPosterApp.Models;

namespace SocialMediaAutoPosterApp.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    
    // Add DbSets for your additional domain entities.
    public DbSet<Agency> Agencies { get; set; }
    public DbSet<Client> Clients { get; set; }

    // Optionally override OnModelCreating to add further configuration.
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Client>()
            .HasOne(c => c.Agency)
            .WithMany(a => a.Clients)
            .HasForeignKey(c => c.AgencyId)
            .OnDelete(DeleteBehavior.Cascade); // Or SetNull if Agency can be deleted
    }
}