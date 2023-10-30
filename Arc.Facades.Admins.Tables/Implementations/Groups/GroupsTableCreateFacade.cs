using Arc.Converters.Views.Admins.Interfaces;
using Arc.Facades.Admins.Tables.Implementations.Base;
using Arc.Facades.Admins.Tables.Interfaces.Groups;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Infrastructure.Repositories.Interfaces;
using Arc.Infrastructure.Transactions.Interfaces;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;
using Arc.Models.DataBase.Models;
using Arc.Models.Views.Admins.Tables.Models.Groups;

namespace Arc.Facades.Admins.Tables.Implementations.Groups;

public sealed class GroupsTableCreateFacade :
    BaseTableCreateFacade
    <
        Group,
        GroupCreateRequest
    >,
    IGroupsTableCreateFacade
{
    public GroupsTableCreateFacade(
        ICreateRepository
            repository,
        IResponsesDomainFacade
            internalFacade,
        IGroupCreateRequestToGroupConverter
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
        GroupTableCreateRequest tableRequest,
        AdminIdentity identity
    ) =>
        await
            Execute(
                tableRequest.Items,
                identity
            );
}