using System.IO;

using Microsoft.Extensions.Configuration;

namespace Arc.Executable.Migration;

internal static class Configuration
{
    public static IConfigurationRoot SetUp()
    {
        var currentDirectory =
            Directory.GetCurrentDirectory();

        return
            new ConfigurationBuilder()
                .SetBasePath(
                    currentDirectory
                )
#if DEBUG
                .AddJsonFile(
                    "appsettings.Development.json",
                    true
                )
#endif
                .AddEnvironmentVariables()
                .Build();
    }
}