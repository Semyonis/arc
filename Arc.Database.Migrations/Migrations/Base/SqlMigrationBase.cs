using Arc.Dependencies.YeSql.Implementations;

using Microsoft.EntityFrameworkCore.Migrations;

namespace Arc.Database.Migrations.Migrations.Base;

public abstract class SqlMigrationBase : Migration
{
    private const string SqlMigrationScripDirectory =
        @"..\..\..\..\Arc.Database.Migrations\Migrations\SqlScrips\";

    private const string SqlFileExtension =
        ".sql";

    protected abstract string File { get; }

    protected abstract string Tag { get; }

    protected override void Up(
        MigrationBuilder migrationBuilder
    )
    {
        var path =
            Path
                .Combine(
                    SqlMigrationScripDirectory,
                    File
                );
        
        var fullSqlFilePath =
            Path
                .GetFullPath(
                    path + SqlFileExtension
                );

        var sqlFileLoadService =
            new SqlFileLoadService();

        var sql =
            sqlFileLoadService
                .Load(
                    fullSqlFilePath,
                    Tag
                );

        migrationBuilder
            .Sql(
                sql
            );
    }
}