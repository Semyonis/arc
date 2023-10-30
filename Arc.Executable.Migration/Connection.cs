using Arc.Database.Context;
using Arc.Infrastructure.Common.Constants;

using Microsoft.EntityFrameworkCore;

namespace Arc.Executable.Migration;

internal sealed record Connection(
    string Host,
    string Port,
    string Name,
    string User,
    string Password
)
{
    public void Migrate()
    {
        var builder =
            new DbContextOptionsBuilder<ArcDatabaseContext>();

        var connectionString =
            GetConnectionString();

        var mySqlServerVersion =
            new MySqlServerVersion(
                MySqlServerVersionConstants.MySqlServerVersion
            );

        builder
            .UseMySql(
                connectionString,
                mySqlServerVersion,
                mySqlDbContextOptionsBuilder =>
                    mySqlDbContextOptionsBuilder
                        .MigrationsAssembly(
                            "Arc.Database.Migrations"
                        )
            );

        using var contextDb =
            new ArcDatabaseContext(
                builder.Options
            );

        contextDb
            .Database
            .Migrate();
    }

    public string GetDescription() =>
        $"Host:{Host}, Port:{Port}, Name:{Name}, User:{User}";

    private string GetConnectionString() =>
        $"server={Host};"
        + $"port={Port};"
        + $"database={Name};"
        + "SslMode=Preferred;"
        + $"uid={User};"
        + $"password={Password};"
        + "Treat Tiny As Boolean=false;Convert Zero Datetime = true";
}