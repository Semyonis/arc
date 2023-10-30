using Arc.Converters.Views.Admins.Interfaces;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.Groups;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Entity.Includes.Extensions.Implementations;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.Groups;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Facades.Admins.Tables.Implementations.Groups;

public sealed class GroupsTableDetailsFacade :
    BaseTableDetailsFacade
    <Group, GroupReadResponse>,
    IGroupsTableDetailsFacade
{
    public GroupsTableDetailsFacade(
        IGroupsReadRepository
            readRepository,
        IResponsesDomainFacade
            internalFacade,
        IGroupToGroupReadResponseConverter
            readConverter,
        IEntityNotFoundExceptionDescriptor
            entityNotFoundExceptionDescriptor
    ) : base(
        readRepository,
        internalFacade,
        readConverter,
        entityNotFoundExceptionDescriptor
    ) { }

    protected override
        Func<IQueryable<Group>, IIncludableQueryable<Group, object>>
        GetInclude() =>
        entity =>
            entity
                .IncludeDescription();
}