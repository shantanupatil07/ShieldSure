// Auth/Commands/Register/RegisterCommandHandler.cs
using AuthService.Application.Common.Interfaces;
using MediatR;

namespace AuthService.Application.Auth.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
{

    private readonly IIdentityService _identityService;

    public RegisterCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[handler] email length = {request.Email?.Length}");
        return await _identityService.CreateUserAsync(
            request.Email, request.Password, request.FirstName, request.LastName, cancellationToken);
    }
}