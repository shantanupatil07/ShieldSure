
// Join table: which admins have which permissions
using AuthService.Domain.Entities;

public class AdminPermission
{
    public Guid AdminId { get; set; }
    public Admin Admin { get; set; } = null!;

    public Guid PermissionId { get; set; }
    public Permission Permission { get; set; } = null!;

    public DateTime GrantedAt { get; set; } = DateTime.UtcNow;
    public Guid? GrantedByAdminId { get; set; }
}