using System;
using System.Collections.Generic;

namespace SocialMediaAutoPosterApp.Models;

public partial class Client
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }

    public Guid AgencyId { get; set; }

    public DateTime CreatedOn { get; set; }

    public string CreatedBy { get; set; } = null!;

    public DateTime? ModifiedOn { get; set; }

    public string? ModifiedBy { get; set; }

    public virtual Agency Agency { get; set; } = null!;
}
