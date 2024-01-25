﻿using Arc.Converters.Views.Admins.Interfaces;
using Arc.Database.Entities.Models;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.SimpleProperties;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Exceptions.Interfaces;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.Views.Admins.Tables.Models.SimpleProperties;

namespace Arc.Facades.Admins.Tables.Implementations.SimpleProperties;

public sealed class SimplePropertiesTableUpdateFacade(
    IUpdateRepository
        repository,
    IResponsesDomainFacade
        internalFacade,
    ISimplePropertyUpdateRequestToSimplePropertiesConverter
        updateConverter,
    ITransactionManager
        transactionManager,
    IBadDataExceptionDescriptor
        badDataExceptionDescriptor
) : BaseTableUpdateFacade
    <
        SimpleProperty,
        SimplePropertyUpdateRequest
    >(
        repository,
        internalFacade,
        updateConverter,
        transactionManager,
        badDataExceptionDescriptor
    ),
    ISimplePropertiesTableUpdateFacade
{
    public async Task<Response> Execute(
        SimplePropertyTableUpdateRequest tableRequest,
        ArcIdentity identity
    ) =>
        await
            Execute(
                tableRequest.Items,
                identity
            );
}