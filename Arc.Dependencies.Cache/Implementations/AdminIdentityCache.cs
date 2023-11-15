using Arc.Dependencies.Cache.Interfaces;
using Arc.Infrastructure.Common.Constants;
using Arc.Models.BusinessLogic.Models.Identities;

namespace Arc.Dependencies.Cache.Implementations;

public sealed class AdminIdentityCache(
    IDistributedCache
        distributedCache,
    ISerializationDecorator
        serializationDecorator
) : IntegerCacheBase<AdminIdentity>(
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