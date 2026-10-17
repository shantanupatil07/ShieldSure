// Contracts/LoginRequest.cs
namespace AuthService.Api.Contracts;

public record LoginRequest(string Email, string Password);