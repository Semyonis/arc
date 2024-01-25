using Arc.Converters.Views.Admins.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

namespace Arc.Facades.Admins.Tables.Implementations.ComplexProperties;

public sealed class ComplexPropertiesTableCreateFacade(
    ICreateRepository
        repository,
    IResponsesDomainFacade
        internalFacade,
    IComplexPropertyCreateRequestToComplexPropertyConverter
        createConverter,
    ITransactionManager
        transactionManager
) : BaseTableCreateFacade
    <
        ComplexProperty,
        ComplexPropertyCreateRequest
    >(
        repository,
        internalFacade,
        createConverter,
        transactionManager
    ),
    IComplexPropertiesTableCreateFacade
{
    public async Task<Response> Execute(
        ComplexPropertyTableCreateRequest request,
        ArcIdentity identity
    ) =>
        await
            Execute(
                request.Items,
                identity
            );
}