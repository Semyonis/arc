using Arc.Infrastructure.ConfigurationSettings.Models;

namespace Arc.Infrastructure.ConfigurationSettings.Implementations;

public sealed class RedisStackSettingsFactory(
    IOptions<RedisStackSettings> option
) :
    SettingsFactoryBase<RedisStackSettings>(
        option
    ),
    IRedisStackSettingsFactory;