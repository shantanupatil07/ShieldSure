// Auth/Commands/Register/RegisterCommand.cs
using MediatR;

namespace AuthService.Application.Auth.Commands.Register;

// Auth/Commands/Register/RegisterCommand.cs
public record RegisterCommand(string Email, string Password, string FirstName, string LastName)
    : IRequest<Guid>
{
    // keeps the plaintext password out of any future request logging
    public override string ToString() =>
        $"RegisterCommand {{ Email = {Email}, FirstName = {FirstName}, LastName = {LastName} }}";
}