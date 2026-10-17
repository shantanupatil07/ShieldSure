using MediatR;

namespace AuthService.Application.Auth.Commands.Login;

public record LoginCommand(string Email, string Password):IRequest<LoginResult>
{
    public override string ToString() => $"LoginCommand - {{Email = {Email}}}";
}