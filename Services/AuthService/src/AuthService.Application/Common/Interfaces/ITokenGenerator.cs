// Common/Interfaces/ITokenGenerator.cs
using AuthService.Application.Common.Models;

namespace AuthService.Application.Common.Interfaces;

public interface ITokenGenerator
{
    (string Token, DateTime ExpiresAt) Generate(AuthenticatedUser user);
}