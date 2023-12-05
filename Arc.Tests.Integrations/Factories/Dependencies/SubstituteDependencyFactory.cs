using System;
using System.Collections.Generic;

using Arc.Database.Context;
using Arc.Dependencies.Identity.Interfaces;
using Arc.Dependencies.Logger.Interfaces;
using Arc.Dependencies.RedisStack.Implementations;
using Arc.Dependencies.RedisStack.Interfaces;
using Arc.Infrastructure.ConfigurationSettings.Models;
using Arc.Infrastructure.Dictionaries.Implementations.Managers;
using Arc.Infrastructure.Dictionaries.Interfaces;
using Arc.Infrastructure.Dictionaries.Interfaces.Managers;
using Arc.Tests.Integrations.Models.Configurations;
using Arc.Tests.Integrations.Models.DataDictionaries;

using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Arc.Tests.Integrations.Factories.Dependencies;

public static class SubstituteDependencyFactory
{
    private static UserManager<IdentityUser> GetUserManager() =>
        Substitute
            .For<UserManager<IdentityUser>>(
                Substitute.For<IUserStore<IdentityUser>>(),
                Substitute.For<IOptions<IdentityOptions>>(),
                Substitute.For<IPasswordHasher<IdentityUser>>(),
                Array.Empty<IUserValidator<IdentityUser>>(),
                Array.Empty<IPasswordValidator<IdentityUser>>(),
                Substitute.For<ILookupNormalizer>(),
                Substitute.For<IdentityErrorDescriber>(),
                Substitute.For<IServiceProvider>(),
                Substitute.For<ILogger<UserManager<IdentityUser>>>()
            );

    private static RoleManager<IdentityRole> GetRoleManager() =>
        Substitute
            .For<RoleManager<IdentityRole>>(
                Substitute.For<IRoleStore<IdentityRole>>(),
                null,
                null,
                null,
                null
            );

    private static IOptions<JwtSettings> GetJwtSettings() =>
        Options
            .Create(
                new JwtSettings
                {
                    Site = "https://www.security.org",
                    SigningKey = "Paris Berlin Cairo Sydney Tokyo Beijing Rome London Athens",
                    ExpiryInMinutesAccess = "30",
                    ExpiryInMinutesRefresh = "60",
                }
            );

    private static IOptions<RedisStackSettings> GetRedisStackSettings() =>
        Options
            .Create(
                new RedisStackSettings
                {
                   Host = "127.0.0.1",
                   Port = "6379",
                }
            );

    public static IDictionary<Type, object> GetInstancesDictionary()
    {
        var dictionaryManager =
            new DictionariesManager();

        return new Dictionary<Type, object>
        {
            {
                typeof(ArcDatabaseContext), DbContextDependency.Create()
            },
            {
                typeof(IDistributedCache), CacheDependency.Create()
            },
            {
                typeof(ILoggerDecorator), new LoggerDecoratorForDebug()
            },
            {
                typeof(IGroupModelsDictionary), new TestModelsDictionaryForDebug(
                    dictionaryManager
                )
            },
            {
                typeof(IComplexPropertyModelsDictionary), new ComplexPropertyModelsDictionaryForDebug(
                    dictionaryManager
                )
            },
            {
                typeof(UserManager<IdentityUser>), GetUserManager()
            },
            {
                typeof(RoleManager<IdentityRole>), GetRoleManager()
            },
            {
                typeof(IOptions<JwtSettings>), GetJwtSettings()
            },
            {
                typeof(IOptions<RedisStackSettings>), GetRedisStackSettings()
            },
            {
                typeof(IUserManagerService), Substitute.For<IUserManagerService>()
            },
            {
                typeof(IUserTokenManagerService), Substitute.For<IUserTokenManagerService>()
            },
            {
                typeof(IUserPasswordManagerService), Substitute.For<IUserPasswordManagerService>()
            },
            {
                typeof(ISignInManagerDecorator), Substitute.For<ISignInManagerDecorator>()
            },
            {
                typeof(IUserManagerDecorator), Substitute.For<IUserManagerDecorator>()
            },
            {
                typeof(IConfiguration), new ConfigurationForDebug()
            },
            {
                typeof(IDictionariesManager), new DictionariesManager()
            },
            {
                typeof(IInMemoryDatabaseConnector), Substitute.For<IInMemoryDatabaseConnector>()
            },
            {
                typeof(IJsonCommandsService), Substitute.For<IJsonCommandsService>()
            },
        };
    }
}