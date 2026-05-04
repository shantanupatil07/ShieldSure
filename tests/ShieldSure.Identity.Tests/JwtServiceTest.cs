using Moq;
using Microsoft.Extensions.Configuration;
using ShieldSure.Identity.Controllers; // Adjust based on your namespace
using Xunit;

using ShieldSure.Identity.Models;
using ShieldSure.Identity.Services.Class;


namespace ShieldSure.Identity.Tests
{
    public class JwtServiceTests
    {
        [Fact] // This attribute tells xUnit this is a test
        public void GenerateToken_ShouldReturnValidString_WhenUserIsValid()
        {
            // 1. Arrange
            var mockConfig = new Mock<IConfiguration>();

            // Set up the "Fake" config values
            mockConfig.Setup(c => c["Jwt:Key"]).Returns("ThisIsASecretKeyThatIsAtLeast64CharactersLong1234567890");
            mockConfig.Setup(c => c["Jwt:Issuer"]).Returns("ShieldSure.Identity");
            mockConfig.Setup(c => c["Jwt:Audience"]).Returns("ShieldSure.Users");

            var service = new AuthService(mockConfig.Object); // Injecting the mock
            var user = new ApplicationUser { Email = "test@example.com", Id = "123" };

            // 2. Act
            var token = service.GenerateJwtToken(user);

            // 3. Assert
            Assert.NotNull(token);
            Assert.IsType<string>(token);
            Assert.NotEmpty(token);
        }
    }
}