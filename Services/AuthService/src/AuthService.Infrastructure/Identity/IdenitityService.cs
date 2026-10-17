using AuthService.Application.Common.Interfaces;
using AuthService.Application.Common.Models;
using AuthService.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using AuthService.Application.Common.Models;

namespace AuthService.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Guid> CreateUserAsync(string email, string password, string firstName, string lastName, CancellationToken ct = default)
    {
        Console.WriteLine($"[identity] email length = {email?.Length}");
        var applicationUser = new ApplicationUser
        {
            UserName = email,
            Email = email,
            FirstName = firstName,
            LastName = lastName
        };

        Console.WriteLine($"DEBUG email = {email}");
        var result = await _userManager.CreateAsync(applicationUser, password);

        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"User creation failed: {errors}");
        }

        return applicationUser.Id;
    }

    public async Task<AuthenticatedUser> ValidateCredentialsAsync(string Email, string Password, CancellationToken ct)
    {

        var user = await _userManager.FindByEmailAsync(Email);
        if (user is null || !user.IsActive)
            return null;

        var passwordOk = await _userManager.CheckPasswordAsync(user, Password);
        if (!passwordOk)
            return null;

        var roles = await _userManager.GetRolesAsync(user);

        return new AuthenticatedUser(
             user.Id,
    user.Email,
    user.FirstName,
     user.LastName,
     roles.ToList()

            );
    }
}