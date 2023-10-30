using Arc.Dependencies.Cache.Interfaces;
using Arc.Infrastructure.Common.Constants;
using Arc.Models.BusinessLogic.Models.Identities;

namespace Arc.Dependencies.Cache.Implementations;

public sealed class UserIdentityCache :
    IntegerCacheBase<UserIdentity>,
    IUserIdentityCache
{
    public UserIdentityCache(
        IDistributedCache
            distributedCache,
        ISerializationDecorator
            serializationDecorator
    ) : base(
        distributedCache,
        serializationDecorator
    ) { }

    protected override string GetKey(
        int userId
    ) =>
        $"{ActorTypeConstants.User}{userId}";
}