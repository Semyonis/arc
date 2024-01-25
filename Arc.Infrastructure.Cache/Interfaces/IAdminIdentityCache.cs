using Arc.Infrastructure.Cache.Interfaces.Base;
using Arc.Models.BusinessLogic.Models;

namespace Arc.Infrastructure.Cache.Interfaces;

public interface IAdminIdentityCache :
    IIntegerCacheBase<ArcIdentity>;