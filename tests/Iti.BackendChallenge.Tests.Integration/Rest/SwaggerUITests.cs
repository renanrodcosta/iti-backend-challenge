using System;
using Xunit;
using System.Threading.Tasks;
using FluentAssertions;

namespace Iti.BackendChallenge.Tests.Integration.Rest
{
    public class SwaggerUITests : BaseRestTests
    {
        [Fact]
        public async Task ShouldReturnOk()
        {
            var response = await _client.GetAsync("/swagger/index.html");
            response.StatusCode.Should().Be(200);
        }
    }
}
