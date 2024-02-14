#nullable disable

using Arc.Database.Migrations.Migrations.Base;

namespace Arc.Database.Migrations.Migrations._2023;

/// <inheritdoc />
public partial class InitActors :
    SqlMigrationBase
{
    protected override string File =>
        @"InitiateActorsScript";

    protected override string Tag =>
        "InitiateActorsScript";
}