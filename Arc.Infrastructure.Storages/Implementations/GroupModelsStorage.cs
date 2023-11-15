using System;
using System.Linq;

using Arc.Converters.Interfaces;
using Arc.Infrastructure.Entity.Includes.Extensions.Implementations;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.DataBase.Models;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Infrastructure.Storages.Implementations;

public sealed class GroupModelsStorage(
        IGroupsReadRepository
            readRepository,
        IGroupModelsDictionary
            dictionary,
        IGroupToGroupModelConverter
            converter
    )
    :
        IntegerKeysModelStorageBase
        <
            GroupModel,
            Group,
            IGroupModelsDictionary,
            IGroupToGroupModelConverter
        >(
            readRepository,
            dictionary,
            converter
        ),
        IGroupModelsStorage
{
    protected override Func
        <
            IQueryable<Group>,
            IIncludableQueryable<Group, object>
        >
        GetInclude() =>
        entity =>
            entity
                .IncludeDescription();
}