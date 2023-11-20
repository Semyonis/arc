using Arc.Dependencies.ConfigurationSettings.Models;

namespace Arc.Dependencies.ConfigurationSettings.Implementations;

public sealed class RedisStackSettingsFactory(
    IOptions<RedisStackSettings> option
) :
    SettingsFactoryBase<RedisStackSettings>(
        option
    ),
    IRedisStackSettingsFactory;