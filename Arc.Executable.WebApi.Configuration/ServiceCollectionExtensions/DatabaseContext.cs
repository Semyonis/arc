using Arc.Database.Context;
using Arc.Infrastructure.Common.Constants;
using Arc.Infrastructure.Common.Constants.Database;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Arc.Executable.WebApi.Configuration.ServiceCollectionExtensions;

public static class DatabaseContext
{
    public static IServiceCollection SetupContext(
        this IServiceCollection services,
        ILoggerFactory loggerFactory,
        IConfiguration configuration
    ) =>
        services
            .AddDbContext<ArcDatabaseContext>(
                options =>
                {
                    options
#if DEBUG
                        .UseLoggerFactory(
                            loggerFactory
                        )
#endif
                        .UseMySql(
                            configuration.GetConnectionStr(),
                            new MySqlServerVersion(
                                MySqlServerVersionConstants.MySqlServerVersion
                            ),
                            mySqlDbContextOptionsBuilder =>
                                mySqlDbContextOptionsBuilder
                                    .MigrationsAssembly(
                                        "Arc.Database.Migrations"
                                    )
                        )
#if DEBUG
                        .EnableSensitiveDataLogging()
                        .LogTo(
                            Console.WriteLine,
                            LogLevel.Information
                        )
#endif
                        ;
                }
            )
            .AddScoped(
                serviceProvider =>
                    new ArcDatabaseContext(
                        serviceProvider
                            .GetService<DbContextOptions<ArcDatabaseContext>>()!
                    )
            );

    private static string GetConnectionStr(
        this IConfiguration configuration
    ) =>
        $"server={configuration[DatabaseSettingsConstants.DatabaseHost]};"
        + $"port={configuration[DatabaseSettingsConstants.DatabasePort]};"
        + $"database={configuration[DatabaseSettingsConstants.DatabaseName]};"
        + $"uid={configuration[DatabaseSettingsConstants.DatabaseUser]};"
        + $"password={configuration[DatabaseSettingsConstants.DatabasePassword]};"
        + "Treat Tiny As Boolean=false;"
        + "Convert Zero Datetime = true";
}