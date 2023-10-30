using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;

namespace Arc.Tests.Integrations.Factories.Dependencies;

public static class CacheDependency
{
    public static IDistributedCache Create()
    {
        var services =
            new ServiceCollection();

        services.AddDistributedMemoryCache();

        var provider =
            services.BuildServiceProvider();

        return
            provider.GetService<IDistributedCache>()!;
    }
}