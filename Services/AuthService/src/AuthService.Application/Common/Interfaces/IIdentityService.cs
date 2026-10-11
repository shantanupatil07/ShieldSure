// Common/Interfaces/IIdentityService.cs
namespace AuthService.Application.Common.Interfaces;

// Common/Interfaces/IIdentityService.cs
public interface IIdentityService
{
     Task<Guid> CreateUserAsync(string email, string password, string firstName, string lastName,
        CancellationToken ct = default);
}