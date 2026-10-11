namespace AuthService.Domain.Entities;
public class Agent
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;

    public Guid AgencyId { get; set; }          // required FK now
    public Agency Agency { get; set; } = null!;
    public Guid? ManagerId { get; set; }        // optional: senior agent/team lead within agency

    public string AgentCode { get; set; } = string.Empty;
    public string LicenseNumber { get; set; } = string.Empty;
    public DateTime LicenseExpiryDate { get; set; }

    public decimal CommissionRate { get; set; }
    public int YearsOfExperience { get; set; }
    public double Rating { get; set; }
    public int TotalPoliciesSold { get; set; }

    public AgentStatus Status { get; set; } = AgentStatus.PendingApproval;
    public bool IsVerified { get; set; }

    public ICollection<string> Specializations { get; set; } = new List<string>();

    public DateTime JoinedDate { get; set; } = DateTime.UtcNow;
}

