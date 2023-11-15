using System.Collections.Generic;

using Arc.Infrastructure.Common.Interfaces;
using Arc.Infrastructure.Common.Models.Dependencies;
using Arc.Infrastructure.Repositories;

namespace Arc.Tests.Integrations.Factories.Dependencies;

public static class SolutionDependencyFactory
{
    public static IEnumerable<DependencyBase> GetDependencyItems() =>
        new IDependencyManager[]
            {
                new DependencyManager(),
                new Infrastructure.Repositories.Read.DependencyManager(),
                new Infrastructure.Transactions.DependencyManager(),
                new Infrastructure.Storages.DependencyManager(),
                new Infrastructure.Services.DependencyManager(),
                new Infrastructure.Exceptions.DependencyManager(),
                new Criteria.PropertyFilters.DependencyManager(),
                new Criteria.CompareFunctions.DependencyManager(),
                new Criteria.FilterParameters.Factories.DependencyManager(),
                new Criteria.FilterParameters.Factories.Generic.DependencyManager(),
                new Converters.Base.DependencyManager(),
                new Converters.DependencyManager(),
                new Converters.Views.Common.DependencyManager(),
                new Converters.Views.Users.DependencyManager(),
                new Converters.Views.Admins.DependencyManager(),
                new Facades.Domain.DependencyManager(),
                new Facades.Admins.DependencyManager(),
                new Facades.Admins.Tables.DependencyManager(),
                new Facades.Anonymous.DependencyManager(),
                new Facades.Authorized.DependencyManager(),
                new Facades.Domain.Filters.DependencyManager(),
                new Facades.Users.DependencyManager(),
                new Arc.Dependencies.Json.DependencyManager(),
                new Arc.Dependencies.ConfigurationSettings.DependencyManager(),
            }
            .SelectMany(
                dependencyList =>
                    dependencyList.GetDependencies()
            );
}