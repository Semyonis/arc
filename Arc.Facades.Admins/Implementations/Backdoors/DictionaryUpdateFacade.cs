using Arc.Facades.Admins.Interfaces.Backdoors;
using Arc.Facades.Domain.Interface;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Models.BusinessLogic.Models.Identities;
using Arc.Models.BusinessLogic.Response;

namespace Arc.Facades.Admins.Implementations.Backdoors;

public sealed class DictionaryUpdateFacade(
        IDictionariesManager
            dictionariesManager,
        IResponsesDomainFacade
            internalFacade
    )
    :
        IDictionaryUpdateFacade
{
    public Task<Response> Execute(
        AdminIdentity identity
    )
    {
        dictionariesManager
            .Update();

        var response =
            internalFacade
                .CreateOkResponse();

        return
            Task
                .FromResult(
                    response
                );
    }
}