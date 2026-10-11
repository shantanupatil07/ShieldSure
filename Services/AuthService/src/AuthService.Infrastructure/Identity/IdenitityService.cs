using AuthService.Application.Common.Interfaces;
using AuthService.Domain.Entities;
using Microsoft.AspNetCore.Identity;

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
        var result = await _userManager.CreateAsync(applicationUser,password);

        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new InvalidOperationException($"User creation failed: {errors}");
        }

        return applicationUser.Id;
    }
}