using Arc.Database.Entities.Models;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.ComplexProperties;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;

namespace Arc.Facades.Admins.Tables.Implementations.ComplexProperties;

public sealed class ComplexPropertiesTableDeleteFacade(
    IDeleteRepository
        repository,
    IComplexPropertiesReadRepository
        readRepository,
    IResponsesDomainFacade
        internalFacade,
    ITransactionManager
        transactionManager
) : BaseTableDeleteFacade
    <ComplexProperty>(
        repository,
        internalFacade,
        transactionManager,
        readRepository
    ),
    IComplexPropertiesTableDeleteFacade;