﻿using Arc.Infrastructure.Cache.Interfaces;
using Arc.Infrastructure.Common.Constants;
using Arc.Models.BusinessLogic.Models;

namespace Arc.Infrastructure.Cache.Implementations;

public sealed class UserIdentityCache(
    IDistributedCache
        distributedCache,
    ISerializationDecorator
        serializationDecorator
) : IntegerCacheBase<ArcIdentity>(
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