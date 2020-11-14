using Moq;
using Pokespeare.Api.Controllers;
using Pokespeare.Api.Models;
using Pokespeare.Api.Services;
using Xunit;

namespace Pokespeare.Api.Tests {
    public class TranslateControllerTests {

        [Fact]
        public void Get_Method_Returns_Translation_Model() {
            // Arrange
            var apiService = new Mock<IApiService>();
            apiService.Setup(a => a.GetPokemonDescription(It.IsAny<string>()))
                .ReturnsAsync("description");
            apiService.Setup(a => a.GetShakespeareTranslation(It.IsAny<string>()))
                .ReturnsAsync("translation");

            // Act
            var controller = new TranslateController(apiService.Object);
            var result = controller.Get("name");

            // Assert
            Assert.IsType<Translation>(result);
            Assert.NotNull(result.Name);
            Assert.NotNull(result.Description); 
        }
    }
}