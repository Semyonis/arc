using Arc.Dependencies.Logger.Interfaces;

namespace Arc.Dependencies.Logger.Implementations;

public sealed class LoggerDecorator(
    ILogger<LoggerDecorator>
        logger
) :
    ILoggerDecorator
{
    public void Log(
        LogLevel logLevel,
        string message,
        Exception exception
    ) =>
        logger
            .Log(
                logLevel,
                exception,
                "{Message}",
                message
            );

    public void LogError(
        Exception exception,
        string message
    ) =>
        logger
            .LogError(
                exception,
                "{Message}",
                message
            );
}