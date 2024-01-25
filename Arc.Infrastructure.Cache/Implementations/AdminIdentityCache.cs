using Arc.Infrastructure.Cache.Interfaces;
using Arc.Infrastructure.Common.Constants;
using Arc.Models.BusinessLogic.Models;

namespace Arc.Infrastructure.Cache.Implementations;

public sealed class AdminIdentityCache(
    IDistributedCache
        distributedCache,
    ISerializationDecorator
        serializationDecorator
) : IntegerCacheBase<ArcIdentity>(
        distributedCache,
        serializationDecorator
    ),
    IAdminIdentityCache
{
    protected override string GetKey(
        int adminId
    ) =>
        $"{ActorTypeConstants.Admin}{adminId}";
}