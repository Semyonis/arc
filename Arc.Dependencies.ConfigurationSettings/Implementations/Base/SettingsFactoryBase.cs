using Arc.Dependencies.ConfigurationSettings.Interfaces.Base;

namespace Arc.Dependencies.ConfigurationSettings.Implementations.Base;

public abstract class SettingsFactoryBase<TResult>(
    IOptions<TResult> option
) :
    ISettingsFactoryBase<TResult>
    where TResult : class
{
    public TResult GetSettings() =>
        option.Value;
}