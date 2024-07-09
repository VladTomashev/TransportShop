using Microsoft.Extensions.Configuration;
using System.IO;

public static class ConfigurationHelper
{
    public static IConfigurationRoot Configuration { get; }

    static ConfigurationHelper()
    {
        Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
    }

    public static string GetConnectionString(string name)
    {
        return Configuration.GetConnectionString(name);
    }
}
