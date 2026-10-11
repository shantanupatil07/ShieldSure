using AuthService.Domain.Enums;

namespace AuthService.Domain.Entities;

public class Admin
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;

    public AdminLevel Level { get; set; } = AdminLevel.Support;
    public string? Department { get; set; } // Claims, Underwriting, Support, Compliance...

    public Guid? CreatedByAdminId { get; set; } // audit trail: who provisioned this admin
    public DateTime? LastActionAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<AdminPermission> AdminPermissions { get; set; } = new List<AdminPermission>();
}




