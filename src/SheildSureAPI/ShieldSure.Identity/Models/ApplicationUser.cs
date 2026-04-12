using Microsoft.AspNetCore.Identity;

namespace ShieldSure.Identity.Models;

public class ApplicationUser : IdentityUser
{
    // These are the custom fields we want for ShieldSure
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}