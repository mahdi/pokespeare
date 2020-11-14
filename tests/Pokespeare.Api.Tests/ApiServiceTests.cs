using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using Pokespeare.Api.Models.PokeApi;
using Pokespeare.Api.Models.ShakespeareApi;
using Pokespeare.Api.Services;
using Xunit;

namespace Pokespeare.Api.Tests
{
    public class ApiServiceTests
    {
        [Fact]
        public async Task Does_PokiApi_Get_String() {
            // Arrange
            var httpClientFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var fixture = new Fixture();

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage {
                    StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(fixture.Create<PokemonSpecies>()),
                            Encoding.UTF8, "application/json"),
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            client.BaseAddress = fixture.Create<Uri>();
            httpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            // Act
            var service = new ApiService(httpClientFactory.Object);
            var result = service.GetPokemonDescription("hey");

            // Assert
            httpClientFactory.Verify(f => f.CreateClient(It.IsAny<String>()), Times.Once);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task Does_ShakespeareApi_Get_String() {
            // Arrange
            var httpClientFactory = new Mock<IHttpClientFactory>();
            var mockHttpMessageHandler = new Mock<HttpMessageHandler>();
            var fixture = new Fixture();

            mockHttpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage {
                    StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(JsonConvert.SerializeObject(fixture.Create<ShakespeareTranslation>()),
                            Encoding.UTF8, "application/json"),
                });

            var client = new HttpClient(mockHttpMessageHandler.Object);
            client.BaseAddress = fixture.Create<Uri>();
            httpClientFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(client);

            // Act
            var service = new ApiService(httpClientFactory.Object);
            var result = service.GetShakespeareTranslation("description");

            // Assert
            httpClientFactory.Verify(f => f.CreateClient(It.IsAny<String>()), Times.Once);

            Assert.NotNull(result);
        }
    }
}