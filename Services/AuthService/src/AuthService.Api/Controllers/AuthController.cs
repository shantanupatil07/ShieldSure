using AuthService.Api.Contracts;
using AuthService.Application.Auth.Commands.Login;
using AuthService.Application.Auth.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : Controller
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest registerRequest, CancellationToken cancellationToken)
    {
        Console.WriteLine($"[controller] email length = {registerRequest.Email?.Length}");

        var command = new RegisterCommand
        (
            registerRequest.Email, registerRequest.Password, registerRequest.FirstName, registerRequest.LastName
        );

        try
        {
            var userId = await _mediator.Send(command, cancellationToken);
            return StatusCode(StatusCodes.Status201Created, new { userId });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }


    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request, CancellationToken cancellationToken)
    {

        try
        {
            var result =  await _mediator.Send(new LoginCommand(request.Email,request.Password),cancellationToken);
            return Ok(new {token = result.Token, expiresAt = result.ExpiresAt});
        }
        catch(UnauthorizedAccessException)
        {
            return Unauthorized(new  {message = "Invalid email or password"});
        }
    }

}