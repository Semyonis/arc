using Arc.Converters.Views.Admins.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Entity.Includes.Extensions.Implementations;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

using Microsoft.EntityFrameworkCore.Query;

namespace Arc.Facades.Admins.Tables.Implementations.ComplexProperties;

public sealed class ComplexPropertiesTableDetailsFacade(
    IComplexPropertiesReadRepository
        readRepository,
    IResponsesDomainFacade
        internalFacade,
    IComplexPropertyToComplexPropertyReadResponseConverter
        readConverter,
    IEntityNotFoundExceptionDescriptor
        entityNotFoundExceptionDescriptor
) : BaseTableDetailsFacade
    <ComplexProperty, ComplexPropertyReadResponse>(
        readRepository,
        internalFacade,
        readConverter,
        entityNotFoundExceptionDescriptor
    ),
    IComplexPropertiesTableDetailsFacade
{
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