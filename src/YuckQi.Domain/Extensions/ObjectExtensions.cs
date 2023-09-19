using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace YuckQi.Domain.Extensions;

public static class ObjectExtensions
{
    private static readonly ConcurrentDictionary<Type, IEnumerable<PropertyInfo>> PropertiesByType = new ();

    public static Dictionary<PropertyInfo, (Object?, Object?)> GetDifferencesByProperty<T>(this T a, T b)
    {
        var properties = GetObjectProperties(typeof(T));
        var values = properties.Select(t =>
        {
            var valueA = a != null ? t.GetValue(a) : null;
            var valueB = b != null ? t.GetValue(b) : null;

            return new KeyValuePair<PropertyInfo, (Object?, Object?)>(t, (valueA, valueB));
        });
        var result = values.Where(t => ! Equals(t.Value.Item1, t.Value.Item2)).ToDictionary(t => t.Key, t => t.Value);

        return result;
    }

    public static HashSet<PropertyInfo> GetNonNullProperties<T>(this T a)
    {
        var properties = GetObjectProperties(typeof(T));
        var values = properties.Select(t =>
        {
            var valueA = a != null ? t.GetValue(a) : null;

            return new KeyValuePair<PropertyInfo, Object?>(t, valueA);
        });
        var result = values.Where(t => t.Value != null).Select(t => t.Key).ToHashSet();

        return result;
    }

    private static IEnumerable<PropertyInfo> GetObjectProperties(Type type)
    {
        return PropertiesByType.GetOrAdd(type, t => t.GetProperties());
    }
}
