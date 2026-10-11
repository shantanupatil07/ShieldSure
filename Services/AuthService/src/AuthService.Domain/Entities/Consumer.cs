using AuthService.Domain.Enums;

namespace AuthService.Domain.Entities;

public class Consumer
{
    public Guid Id { get; set; } // same as ApplicationUser.Id (1:1)
    public Guid UserId { get; set; }
    public ApplicationUser User { get; set; } = null!;

    public string? Occupation { get; set; }
    public string PreferredContactMethod { get; set; } = "Email"; // Email/SMS/Call
    public KycStatus KycStatus { get; set; } = KycStatus.Pending;

    public string? NomineeName { get; set; }
    public string? NomineeRelationship { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

