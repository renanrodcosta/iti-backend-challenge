using System;
using Xunit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Iti.BackendChallenge.WebAPI;

namespace Iti.BackendChallenge.Tests.Integration.Rest
{
    public abstract class BaseRestTests
    {
        protected readonly TestServer _server;
        protected readonly HttpClient _client;

        public BaseRestTests()
        {
            var webHostBuilder = new WebHostBuilder();
            _server = new TestServer(webHostBuilder.UseStartup<Startup>());
            _client = _server.CreateClient();
        }
    }
}
