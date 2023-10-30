namespace Arc.Dependencies.ConfigurationSettings.Interfaces.Base;

public interface ISettingsFactoryBase<out TResult>
    where TResult : class
{
    TResult GetSettings();
}