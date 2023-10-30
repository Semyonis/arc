using Arc.Converters.Views.Admins.Interfaces;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Entity.Includes.Extensions.Implementations;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Facades.Admins.Tables.Implementations.ComplexProperties;

public sealed class ComplexPropertiesTableDetailsFacade :
    BaseTableDetailsFacade
    <ComplexProperty, ComplexPropertyReadResponse>,
    IComplexPropertiesTableDetailsFacade
{
    public ComplexPropertiesTableDetailsFacade(
        IComplexPropertiesReadRepository
            readRepository,
        IResponsesDomainFacade
            internalFacade,
        IComplexPropertyToComplexPropertyReadResponseConverter
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
        Func<
            IQueryable<ComplexProperty>,
            IIncludableQueryable<ComplexProperty, object>
        > GetInclude() =>
        entity =>
            entity
                .IncludeDescription()
                .IncludeGroupDescription();
}