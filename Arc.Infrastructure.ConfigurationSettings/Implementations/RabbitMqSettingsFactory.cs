using Arc.Infrastructure.ConfigurationSettings.Models;

namespace Arc.Infrastructure.ConfigurationSettings.Implementations;

public sealed class RabbitMqSettingsFactory(
    IOptions<RabbitMqSettings> option
) :
    SettingsFactoryBase<RabbitMqSettings>(
        option
    ),
    IRabbitMqSettingsFactory;