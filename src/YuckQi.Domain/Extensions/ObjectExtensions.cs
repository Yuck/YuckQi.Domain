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
        var properties = PropertiesByType.GetOrAdd(typeof(T), type => type.GetProperties());
        var values = properties.Select(t => new KeyValuePair<PropertyInfo, (Object?, Object?)>(t, (t.GetValue(a), t.GetValue(b))));
        var differences = values.Where(t => ! Equals(t.Value.Item1, t.Value.Item2)).ToDictionary(t => t.Key, t => t.Value);

        return differences;
    }
}
