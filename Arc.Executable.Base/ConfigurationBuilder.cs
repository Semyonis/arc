using System.IO;

using Microsoft.Extensions.Configuration;

namespace Arc.Executable.Base;

public sealed class ConfigurationBuilder
{
    public IConfigurationRoot Build()
    {
        var currentDirectory =
            Directory.GetCurrentDirectory();

        return
            new Microsoft.Extensions.Configuration.ConfigurationBuilder()
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