// Common/Models/AuthenticatedUser.cs
namespace AuthService.Application.Common.Models;

public record AuthenticatedUser(
    Guid Id,
    string ?Email,
    string FirstName,
    string LastName,
    IReadOnlyList<string> Roles);