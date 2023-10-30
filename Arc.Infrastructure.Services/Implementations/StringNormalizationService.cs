using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

using Arc.Infrastructure.Common.Extensions;
using Arc.Infrastructure.Services.Attributes;
using Arc.Infrastructure.Services.Interfaces;

namespace Arc.Infrastructure.Services.Implementations;

public sealed class StringNormalizationService :
    IStringNormalizationService
{
    private readonly ConcurrentDictionary
        <
            Type,
            IReadOnlyList<PropertyInfo>
        >
        _cacheFields =
            new();

    public object Normalize(
        object value
    )
    {
        if (value is string stringValue)
        {
            return
                TrimSpaces(
                    stringValue
                );
        }

        var type =
            value.GetType();

        var isNotUpdatableType =
            IsNotUpdatableType(
                type
            );

        if (isNotUpdatableType)
        {
            return value;
        }

        var isStringEnumerable =
            typeof(IEnumerable<string>)
                .IsAssignableFrom(
                    type
                );

        if (isStringEnumerable)
        {
            return
                NormalizeStringEnumerable(
                    value,
                    type
                );
        }

        var isEnumerable =
            typeof(IEnumerable)
                .IsAssignableFrom(
                    type
                );

        if (isEnumerable)
        {
            return
                NormalizeEnumerable(
                    value
                );
        }

        var properties =
            GetObjectProperties(
                type
            );

        if (properties.IsNotEmpty())
        {
            foreach (var property in properties)
            {
                NormalizeProperty(
                    value,
                    property
                );
            }
        }

        return value;
    }

    private void NormalizeProperty(
        object value,
        PropertyInfo propertyInfo
    )
    {
        var valueFields =
            propertyInfo
                .GetValue(
                    value
                );

        if (valueFields == default)
        {
            return;
        }

        var newValue =
            Normalize(
                valueFields
            );

        propertyInfo
            .SetValue(
                value,
                newValue
            );
    }

    private static bool IsNotUpdatableType(
        Type type
    )
    {
        if (type.IsPrimitive)
        {
            return true;
        }

        if (type.IsEnum)
        {
            return true;
        }

        var isAssignableFromStream =
            typeof(Stream)
                .IsAssignableFrom(
                    type
                );

        if (isAssignableFromStream)
        {
            return true;
        }

        var isAssignableFromDateTime =
            typeof(DateTime)
                .IsAssignableFrom(
                    type
                );

        if (isAssignableFromDateTime)
        {
            return true;
        }

        var isAssignableFromTimeSpan =
            typeof(TimeSpan)
                .IsAssignableFrom(
                    type
                );

        if (isAssignableFromTimeSpan)
        {
            return true;
        }

        return false;
    }

    private object NormalizeEnumerable(
        object value
    )
    {
        var enumerable =
            (IEnumerable)value;

        foreach (var valueField in enumerable)
        {
            Normalize(
                valueField
            );
        }

        return value;
    }

    private object NormalizeStringEnumerable(
        object value,
        Type type
    )
    {
        var newArray =
            new List<string>();

        var enumerable =
            (IEnumerable<string>)value;

        foreach (var valueField in enumerable)
        {
            var normalizeStringFields =
                (string)Normalize(
                    valueField
                );

            newArray
                .Add(
                    normalizeStringFields
                );
        }

        var isAssignableFromStringList =
            typeof(List<string>)
                .IsAssignableFrom(
                    type
                );

        if (isAssignableFromStringList)
        {
            return newArray;
        }

        return
            type.IsArray
                ? newArray.ToArray()
                : value;
    }

    private IReadOnlyList<PropertyInfo>? GetObjectProperties(
        Type typeObject
    )
    {
        var isSuccess =
            _cacheFields
                .TryGetValue(
                    typeObject,
                    out var properties
                );

        if (isSuccess)
        {
            return properties;
        }

        var otherProperties =
            typeObject
                .GetProperties()
                .Where(
                    IsUpdatable
                )
                .ToList();

        if (otherProperties.IsNotEmpty())
        {
            _cacheFields
                .TryAdd(
                    typeObject,
                    otherProperties
                );
        }

        return otherProperties;
    }

    private static bool IsUpdatable(
        PropertyInfo propertyInfo
    )
    {
        var isNotUpdatable =
            Attribute
                .IsDefined(
                    propertyInfo,
                    typeof(DontNormalizeStringAttribute)
                );

        return !isNotUpdatable;
    }

    private static string ReplaceMultiSpacesByOne(
        string value
    )
    {
        var matchTimeout =
            TimeSpan
                .FromSeconds(
                    3
                );

        return
            Regex
                .Replace(
                    value,
                    @"\s+",
                    " ",
                    RegexOptions.None,
                    matchTimeout
                );
    }

    private static string TrimSpaces(
        string value
    ) =>
        ReplaceMultiSpacesByOne(
                value
            )
            .Trim();
}