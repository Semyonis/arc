using System;

using Arc.Executable.Base;
using Arc.Executable.Migration;

var config =
    new ConfigurationBuilder()
        .Build();

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