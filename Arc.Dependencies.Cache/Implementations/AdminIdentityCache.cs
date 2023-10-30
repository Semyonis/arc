using Arc.Dependencies.Cache.Interfaces;
using Arc.Infrastructure.Common.Constants;
using Arc.Models.BusinessLogic.Models.Identities;

namespace Arc.Dependencies.Cache.Implementations;

public sealed class AdminIdentityCache :
    IntegerCacheBase<AdminIdentity>,
    IAdminIdentityCache
{
    public AdminIdentityCache(
        IDistributedCache
            distributedCache,
        ISerializationDecorator
            serializationDecorator
    ) : base(
        distributedCache,
        serializationDecorator
    ) { }

    protected override string GetKey(
        int adminId
    ) =>
        $"{ActorTypeConstants.Admin}{adminId}";
}