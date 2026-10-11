// Lookup table of all possible permissions in the system
public class Permission
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;   // e.g. "agents.approve", "claims.override"
    public string Description { get; set; } = string.Empty;
}