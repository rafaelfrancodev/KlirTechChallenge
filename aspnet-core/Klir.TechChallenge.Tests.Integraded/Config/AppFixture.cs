using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Klir.TechChallenge.Tests.Integraded.Config
{
    public class AppFixture : WebApplicationFactory<TestStartup>
    {
        protected override IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x => x.UseStartup<TestStartup>().UseTestServer());

        protected override IHost CreateHost(IHostBuilder builder)
        {
            builder.UseContentRoot(Directory.GetCurrentDirectory());
            var host = base.CreateHost(builder);
            return host;
        }
    }
}
