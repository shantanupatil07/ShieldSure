
namespace AuthService.Application.Auth.Commands.Login;
public record LoginResult(string Token, DateTime ExpiresAt);