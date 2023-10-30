using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Arc.Tests.Integrations.Models.Configurations;

public class ConfigurationForDebug :
    IConfiguration
{
    public IEnumerable<IConfigurationSection> GetChildren() =>
        throw new NotImplementedException();

    public IChangeToken GetReloadToken() =>
        throw new NotImplementedException();

    public IConfigurationSection GetSection(
        string key
    ) =>
        throw new NotImplementedException();

    public string this[
        string key
    ]
    {
        get => string.Empty;
#pragma warning disable CS8767
        set => throw new NotImplementedException();
#pragma warning restore CS8767
    }
}