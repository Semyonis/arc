namespace Arc.Dependencies.ConfigurationSettings.Implementations;

public sealed class JwtSettingsFactory :
    SettingsFactoryBase<JwtSettings>,
    IJwtSettingsFactory
{
    public JwtSettingsFactory(
        IOptions<JwtSettings> option
    ) : base(
        option
    ) { }
}