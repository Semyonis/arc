namespace Arc.Dependencies.ConfigurationSettings.Implementations;

public sealed class JwtSettingsFactory(
    IOptions<JwtSettings> option
) :
    SettingsFactoryBase<JwtSettings>(
        option
    ),
    IJwtSettingsFactory;