using Arc.Converters.Views.Admins.Interfaces;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.ComplexProperties;

namespace Arc.Facades.Admins.Tables.Implementations.ComplexProperties;

public sealed class ComplexPropertiesTableCreateFacade :
    BaseTableCreateFacade
    <
        ComplexProperty,
        ComplexPropertyCreateRequest
    >,
    IComplexPropertiesTableCreateFacade
{
    public ComplexPropertiesTableCreateFacade(
        ICreateRepository
            repository,
        IResponsesDomainFacade
            internalFacade,
        IComplexPropertyCreateRequestToComplexPropertyConverter
            createConverter,
        ITransactionManager
            transactionManager,
        IDictionariesManager
            dictionariesManager
    ) : base(
        repository,
        internalFacade,
        createConverter,
        transactionManager,
        dictionariesManager
    ) { }

    public async Task<Response> Execute(
        ComplexPropertyTableCreateRequest request,
        AdminIdentity identity
    ) =>
        await
            Execute(
                request.Items,
                identity
            );
}