using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.SimpleProperties;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Repositories.Read.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.DataBase.Models;

namespace Arc.Facades.Admins.Tables.Implementations.SimpleProperties;

public sealed class SimplePropertiesTableDeleteFacade :
    BaseTableDeleteFacade
    <SimpleProperty>,
    ISimplePropertiesTableDeleteFacade
{
    public SimplePropertiesTableDeleteFacade(
        IDeleteRepository
            repository,
        ISimplePropertiesReadRepository
            readRepository,
        IResponsesDomainFacade
            internalFacade,
        ITransactionManager
            transactionManager
    ) : base(
        repository,
        internalFacade,
        transactionManager,
        readRepository
    ) { }
}