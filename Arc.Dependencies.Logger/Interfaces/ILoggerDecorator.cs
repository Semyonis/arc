namespace Arc.Dependencies.Logger.Interfaces;

public interface ILoggerDecorator
{
    void Log(
        LogLevel logLevel,
        string message,
        Exception exception
    );

    void LogError(
        Exception exception,
        string message
    );
}