using System;

using Arc.Executable.Migration;

var config =
    Configuration.SetUp();

var connection =
    new Connection(
        config
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