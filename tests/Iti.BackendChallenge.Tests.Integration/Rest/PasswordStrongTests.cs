using FluentAssertions;
using Newtonsoft.Json;
using System.Text;
using Xunit;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;


namespace Iti.BackendChallenge.Tests.Integration.Rest
{
    public class StrongPasswordTests : BaseRestTests
    {
        [Fact]
        public async Task ShouldReturnSuccessNoContent()
        {
            var body = new { value = "12345Aa!@" };
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/v1/strong-password", data);
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }

        [Fact]
        public async Task ShouldReturnBadRequestWhenBodyIsDigit()
        {
            var body = new { value = 32424 };
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/v1/strong-password", data);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task ShouldReturnUnprocessableEntityWhenBodyIsInvalid()
        {
            const int unprocessableEntity = 422;
            var body = new { value = "djsn" };
            var json = JsonConvert.SerializeObject(body);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/v1/strong-password", data);
            response.StatusCode.Should().Be(unprocessableEntity);
        }
    }
}
