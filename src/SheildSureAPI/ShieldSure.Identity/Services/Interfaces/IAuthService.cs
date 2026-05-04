
using ShieldSure.Identity.Models;
namespace ShieldSure.Identity.Services.Interfaces
{
    public interface IAuthService
    {


        string GenerateJwtToken(ApplicationUser user);
    }
}
