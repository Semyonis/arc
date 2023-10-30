using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using NLog.Web;

namespace Arc.Executable.WebApi.Configuration.WebHostBuilderExtensions;

public static class Logs
{
    public static IWebHostBuilder SetupLogs(
        this IWebHostBuilder builder
    ) =>
        builder
            .ConfigureLogging(
                (
                    _,
                    logging
                ) =>
                {
                    logging.ClearProviders();
#if DEBUG
                    logging
                        .AddFilter(
                            "System",
                            LogLevel.Information
                        )
                        .AddFilter(
                            DbLoggerCategory.Database.Command.Name,
                            LogLevel.Information
                        )
                        .AddConsole();
#else
                logging
                    .AddFilter(
                        "Microsoft",
                        LogLevel.Critical
                    )
                    .AddFilter(
                        "System",
                        LogLevel.Critical
                    );
#endif
                }
            )
            .UseNLog(
                new()
                {
                    IncludeScopes = true,
                }
            );
}