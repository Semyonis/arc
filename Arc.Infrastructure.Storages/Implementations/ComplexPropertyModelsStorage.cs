using System;
using System.Linq;

using Arc.Converters.Interfaces;
using Arc.Infrastructure.Entity.Includes.Extensions.Implementations;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.DataBase.Models;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Infrastructure.Storages.Implementations;

public sealed class ComplexPropertyModelsStorage :
    IntegerKeysModelStorageBase
    <
        ComplexPropertyModel,
        ComplexProperty,
        IComplexPropertyModelsDictionary,
        IComplexPropertyToComplexPropertyModelConverter
    >,
    IComplexPropertyModelsStorage
{
    public ComplexPropertyModelsStorage(
        IComplexPropertiesReadRepository
            readRepository,
        IComplexPropertyModelsDictionary
            dictionary,
        IComplexPropertyToComplexPropertyModelConverter
            converter
    ) : base(
        readRepository,
        dictionary,
        converter
    ) { }

    protected override Func
        <
            IQueryable<ComplexProperty>,
            IIncludableQueryable<ComplexProperty, object>
        >
        GetInclude() =>
        entity =>
            entity
                .IncludeDescription()
                .IncludeGroupDescription();
}