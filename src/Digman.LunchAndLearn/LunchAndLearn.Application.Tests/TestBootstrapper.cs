using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace LunchAndLearn.Application.Tests
{
    public class TestBootstrapper<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((hostingContext, configurationBuilder) =>
            {
                var type = typeof(TStartup);
                var path = @"C:\\OriginalApplication";

                configurationBuilder.AddJsonFile($"{path}\\appsettings.json", optional: true, reloadOnChange: true);
                configurationBuilder.AddEnvironmentVariables();
            });
        }
    }
}