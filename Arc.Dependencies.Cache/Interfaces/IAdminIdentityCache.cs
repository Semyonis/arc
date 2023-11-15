using Arc.Dependencies.Cache.Interfaces.Base;
using Arc.Models.BusinessLogic.Models.Identities;

namespace Arc.Dependencies.Cache.Interfaces;

public interface IAdminIdentityCache :
    IIntegerCacheBase<AdminIdentity>;