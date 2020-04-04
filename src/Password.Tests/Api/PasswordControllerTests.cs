using Password.Api;
using Password.Domain.Commands;
using Password.Domain.Results;

using Microsoft.AspNetCore.Mvc.Testing;

using Newtonsoft.Json;

using System.Net;
using System.Net.Http;
using System.Text;

using WireMock.Server;

using Xunit;

namespace Password.Tests
{
    public class PasswordControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WireMockServer mockServer;
        private readonly HttpClient client;
        public PasswordControllerTests(WebApplicationFactory<Startup> factory)
        {
            client = factory.CreateClient();
            mockServer = FluentMockServer.Start();
        }

        [Fact]
        public async void ShouldReturnOk()
        {
            //Arrange
            var command = new PasswordCheckCommand();
            var request = new HttpRequestMessage(HttpMethod.Post, $"/api/password/check")
            {
                Content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json")
            };

            //Act
            var response = await client.SendAsync(request);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }


        [Theory]
        [InlineData(false, "")]
        [InlineData(false, "aa")]
        [InlineData(false, "ab")]
        [InlineData(false, "AAAbbbCc")]
        [InlineData(true, "AbTp9!foo")]
        public async void ShouldReturnIsValid(bool expected, string password)
        {
            //Arrange
            var command = new PasswordCheckCommand()
            {
                Password = password
            };
            var request = new HttpRequestMessage(HttpMethod.Post, $"/api/password/check")
            {
                Content = new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json")
            };

            //Act
            var response = await client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<PasswordCheckResult>(content);

            //Assert
            Assert.Equal(expected, result.IsValid);
        }

    }
}
