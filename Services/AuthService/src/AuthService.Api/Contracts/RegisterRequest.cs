// Contracts/RegisterRequest.cs
namespace AuthService.Api.Contracts;

public record RegisterRequest(string Email, string Password, string FirstName, string LastName);