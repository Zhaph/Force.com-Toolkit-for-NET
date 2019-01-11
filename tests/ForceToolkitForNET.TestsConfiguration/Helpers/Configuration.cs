using Microsoft.Extensions.Configuration;

namespace Salesforce.Force.TestsConfiguration.Helpers
{
    public static class Configuration
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddJsonFile("appsettings.local.json", optional: true)
                .AddEnvironmentVariables()
                .Build();
        }

        public static SalesforceConfiguration GetApplicationConfiguration(string outputPath)
        {
            var configuration = new SalesforceConfiguration();

            var iConfig = GetIConfigurationRoot(outputPath);

            iConfig
                .GetSection("Salesforce")
                .Bind(configuration);

            return configuration;
        }
    }
}
