using System;
using System.Collections.Generic;

namespace SocialMediaAutoPosterApp.Models;

public partial class Agency
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public string OwnerUserId { get; set; } = null!;

    public string? OwnerId { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? UpdatedOn { get; set; }

    public string? UpdatedBy { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual AspNetUser? Owner { get; set; }
}
