
using AuthService.Application.Common.Interfaces;
using MediatR;

namespace AuthService.Application.Auth.Commands.Login;

public class LoginCommandHandler :  IRequestHandler<LoginCommand, LoginResult>
{
    private readonly IIdentityService _identityService;
    private readonly ITokenGenerator _tokenGenerator;

    public LoginCommandHandler(IIdentityService identityService, ITokenGenerator tokenGenerator)
    {
        _identityService = identityService;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<LoginResult> Handle(LoginCommand loginCommand, CancellationToken cancellationToken)
    {
        var user = await _identityService.ValidateCredentialsAsync(loginCommand.Email ,loginCommand.Password, cancellationToken);

        if(user is null)
        {
            throw new UnauthorizedAccessException();
        }

        var (token, expiresAt) = _tokenGenerator.Generate(user);
        return new LoginResult(token, expiresAt);
    
    }

}