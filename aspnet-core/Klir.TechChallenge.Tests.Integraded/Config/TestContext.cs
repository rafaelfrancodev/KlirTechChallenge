using Klir.TechChallenge.Web.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace Klir.TechChallenge.Tests.Integraded.Config
{
    public class TestContext
    {
        public HttpClient Client { get; set; }
        private TestServer _server;

        public TestContext()
        {
            var webHostBuilder = new WebHostBuilder()
                .UseStartup<Startup>();
            SetupClient(webHostBuilder);
        }

        private void SetupClient(IWebHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                    .BuildServiceProvider();
                var sp = services.BuildServiceProvider();
            });

            _server = new TestServer(builder);
            Client = _server.CreateClient();
        }
    }
}
