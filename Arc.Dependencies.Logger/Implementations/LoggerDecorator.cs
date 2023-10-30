using Arc.Dependencies.Logger.Interfaces;

namespace Arc.Dependencies.Logger.Implementations;

public sealed class LoggerDecorator :
    ILoggerDecorator
{
    public void Log(
        LogLevel logLevel,
        string message,
        Exception exception
    ) =>
        _logger
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
        _logger
            .LogError(
                exception,
                "{Message}",
                message
            );

#region Constructor

    private readonly ILogger<LoggerDecorator>
        _logger;

    public LoggerDecorator(
        ILogger<LoggerDecorator>
            logger
    ) =>
        _logger =
            logger;

#endregion
}