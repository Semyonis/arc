using Arc.Dependencies.ConfigurationSettings.Interfaces.Base;

namespace Arc.Dependencies.ConfigurationSettings.Implementations.Base;

public abstract class SettingsFactoryBase<TResult> :
    ISettingsFactoryBase<TResult>
    where TResult : class
{
    private readonly IOptions<TResult> _options;

    protected SettingsFactoryBase(
        IOptions<TResult> option
    ) =>
        _options =
            option;

    public TResult GetSettings() =>
        _options.Value;
}