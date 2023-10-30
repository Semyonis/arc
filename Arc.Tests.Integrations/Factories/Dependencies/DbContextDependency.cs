using System;

using Arc.Database.Context;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Arc.Tests.Integrations.Factories.Dependencies;

public static class DbContextDependency
{
    public static ArcDatabaseContext Create() =>
        new(
            GetOptions()
        );

    private static DbContextOptions<ArcDatabaseContext> GetOptions()
    {
        var builder =
            new DbContextOptionsBuilder<ArcDatabaseContext>();

        builder
            .EnableSensitiveDataLogging()
            .LogTo(
                Console.WriteLine,
                LogLevel.Information
            );

        var databaseName =
            "db" + Guid.NewGuid();

        var transactionIgnoredWarning =
            InMemoryEventId.TransactionIgnoredWarning;

        builder
            .UseInMemoryDatabase(
                databaseName
            )
            .ConfigureWarnings(
                warningsConfigurationBuilder =>
                    warningsConfigurationBuilder
                        .Ignore(
                            transactionIgnoredWarning
                        )
            );

        return
            builder.Options;
    }
}