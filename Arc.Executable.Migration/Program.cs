using System;
using System.IO;

using Arc.Infrastructure.Common.Constants.Database;

using Microsoft.Extensions.Configuration;

namespace Arc.Executable.Migration;

internal static class Program
{
    private static void Main()
    {
        var config =
            SetUpConfigurationRoot();

        var connection =
            new Connection(
                config[DatabaseSettingsConstants.DatabaseHost]!,
                config[DatabaseSettingsConstants.DatabasePort]!,
                config[DatabaseSettingsConstants.DatabaseName]!,
                config[DatabaseSettingsConstants.DatabaseUser]!,
                config[DatabaseSettingsConstants.DatabasePassword]!
            );

        var connectionDescription =
            connection.GetDescription();

        Console
            .WriteLine(
                connectionDescription
            );

        Console
            .WriteLine(
                "Migration started"
            );

        connection
            .Migrate();

        Console
            .WriteLine(
                "Migration done"
            );
    }

    private static IConfigurationRoot SetUpConfigurationRoot()
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