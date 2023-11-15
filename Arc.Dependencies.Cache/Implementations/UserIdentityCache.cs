using Arc.Dependencies.Cache.Interfaces;
using Arc.Infrastructure.Common.Constants;
using Arc.Models.BusinessLogic.Models.Identities;

namespace Arc.Dependencies.Cache.Implementations;

public sealed class UserIdentityCache(
        IDistributedCache
            distributedCache,
        ISerializationDecorator
            serializationDecorator
    )
    :
        IntegerCacheBase<UserIdentity>(
            distributedCache,
            serializationDecorator
        ),
        IUserIdentityCache
{
    protected override string GetKey(
        int userId
    ) =>
        $"{ActorTypeConstants.User}{userId}";
}