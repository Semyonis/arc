using Arc.Infrastructure.ConfigurationSettings.Models;

namespace Arc.Infrastructure.ConfigurationSettings.Implementations;

public sealed class JwtSettingsFactory(
    IOptions<JwtSettings> option
) :
    SettingsFactoryBase<JwtSettings>(
        option
    ),
    IJwtSettingsFactory;