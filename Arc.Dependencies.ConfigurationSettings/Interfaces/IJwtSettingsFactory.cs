using Arc.Dependencies.ConfigurationSettings.Interfaces.Base;
using Arc.Dependencies.ConfigurationSettings.Models;

namespace Arc.Dependencies.ConfigurationSettings.Interfaces;

public interface IJwtSettingsFactory :
    ISettingsFactoryBase<JwtSettings>;