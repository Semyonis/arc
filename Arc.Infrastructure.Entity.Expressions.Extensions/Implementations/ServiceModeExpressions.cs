using Arc.Infrastructure.Common.Enums;
using Arc.Models.DataBase.Models;

namespace Arc.Infrastructure.Entity.Expressions.Extensions.Implementations;

public static class ServiceModeExpressions
{
    public static Expression<Func<ServiceMode, int>> GetId() =>
        entity =>
            entity.Id;

    public static Expression<Func<ServiceMode, int>> GetUpdatedById() =>
        entity =>
            entity.UpdatedById;

    public static Expression<Func<ServiceMode, Admin>> GetUpdatedBy() =>
        entity =>
            entity.UpdatedBy;

    public static Expression<Func<ServiceMode, DateTime>> GetUpdateDateTime() =>
        entity =>
            entity.UpdateDateTime;

    public static Expression<Func<ServiceMode, ServiceModeType>> GetMode() =>
        entity =>
            entity.Mode;
}