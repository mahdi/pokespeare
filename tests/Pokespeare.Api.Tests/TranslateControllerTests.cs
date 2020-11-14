using System;
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
        
        [Fact]
        public void Get_Method_Returns_Error_Message_If_Shakespeare_Api_Limit_Reached() {
            // Arrange
            var apiService = new Mock<IApiService>();
            apiService.Setup(a => a.GetPokemonDescription(It.IsAny<string>()))
                .ReturnsAsync("description");
            apiService.Setup(a => a.GetShakespeareTranslation(It.IsAny<string>()))
                .ThrowsAsync(new Exception("API limit reached"));

            // Act
            var controller = new TranslateController(apiService.Object);
            var result = controller.Get("name");

            // Assert
            Assert.IsType<Translation>(result);
            Assert.NotNull(result.Name);
            Assert.Equal("One or more errors occurred. (API limit reached)", result.Description); 
        }
    }
}