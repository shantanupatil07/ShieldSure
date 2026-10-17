// Common/Interfaces/IIdentityService.cs
using AuthService.Application.Common.Models;

namespace AuthService.Application.Common.Interfaces;

// Common/Interfaces/IIdentityService.cs
public interface IIdentityService
{
     Task<Guid> CreateUserAsync(string email, string password, string firstName, string lastName,
        CancellationToken ct = default);

        Task<AuthenticatedUser> ValidateCredentialsAsync(string Email, string Password, CancellationToken ct);
}