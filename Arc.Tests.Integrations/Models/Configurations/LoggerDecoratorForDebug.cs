using System;

using Arc.Dependencies.Logger.Interfaces;

using Microsoft.Extensions.Logging;

namespace Arc.Tests.Integrations.Models.Configurations;

public sealed class LoggerDecoratorForDebug :
    ILoggerDecorator
{
    public void Log(
        LogLevel logLevel,
        string message,
        Exception exception
    ) { }

    public void LogError(
        Exception exception,
        string message
    ) { }
}