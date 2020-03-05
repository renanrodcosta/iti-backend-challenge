using System;
using Xunit;
using System.Threading.Tasks;
using FluentAssertions;

namespace Iti.BackendChallenge.Tests.Integration.Rest
{
    public class HealthCheckTests : BaseRestTests
    {
        [Fact]
        public async Task ShouldReturnOk()
        {
            var response = await _client.GetAsync("/health-check");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            responseString.Should().Be("Healthy");
        }
    }
}
