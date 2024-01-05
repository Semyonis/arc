using Arc.Database.Context;
using Arc.Infrastructure.Common.Constants;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using static Arc.Infrastructure.Common.Constants.Database.DatabaseSettingsConstants;

namespace Arc.Executable.Migration;

internal sealed class Connection(IConfiguration configurationRoot)
{
    private readonly string _host =
        configurationRoot[DatabaseHost]!;

    private readonly string _name =
        configurationRoot[DatabaseName]!;

    private readonly string _password =
        configurationRoot[DatabasePassword]!;

    private readonly string _port =
        configurationRoot[DatabasePort]!;

    private readonly string _user =
        configurationRoot[DatabaseUser]!;

    internal void Migrate()
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

    internal string GetDescription() =>
        $"Host:{_host}, Port:{_port}, Name:{_name}, User:{_user}";

    private string GetConnectionString() =>
        $"server={_host};"
        + $"port={_port};"
        + $"database={_name};"
        + "SslMode=Preferred;"
        + $"uid={_user};"
        + $"password={_password};"
        + "Treat Tiny As Boolean=false;Convert Zero Datetime = true";
}