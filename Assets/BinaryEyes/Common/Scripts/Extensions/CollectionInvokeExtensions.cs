using System;
using System.Collections.Generic;

namespace BinaryEyes.Common.Extensions
{
    /// <summary>
    /// Extends collection types with common action invocations.
    /// </summary>
    public static class CollectionInvokeExtensions
    {
        public static Dictionary<TKey, TValue> ForEachValue<TKey, TValue>(this Dictionary<TKey, TValue> collection, Action<TValue> action)
        {
            if (action == null || collection == null)
                return collection;

            foreach (var entry in collection)
                action.Invoke(entry.Value);

            return collection;
        }

        public static Dictionary<TKey, TValue> ForEachKey<TKey, TValue>(this Dictionary<TKey, TValue> collection, Action<TKey> action)
        {
            if (action == null || collection == null)
                return collection;

            foreach (var entry in collection)
                action.Invoke(entry.Key);

            return collection;
        }

        public static List<T> Invoke<T>(this List<T> collection, Action<T> action)
        {
            if (action == null || collection == null)
                return collection;

            foreach (var entry in collection)
                action(entry);

            return collection;
        }

        public static IReadOnlyCollection<T> Invoke<T>(this IReadOnlyCollection<T> collection, Action<T> action)
        {
            if (action == null || collection == null)
                return collection;

            foreach (var entry in collection)
                action.Invoke(entry);

            return collection;
        }

        public static IReadOnlyList<T> Invoke<T>(this IReadOnlyList<T> collection, Action<T> action)
        {
            if (action == null || collection == null)
                return collection;

            foreach (var item in collection)
                action.Invoke(item);

            return collection;
        }

        public static T[] ForEach<T>(this T[] collection, Action<T> action)
        {
            if (action == null || collection == null)
                return collection;

            foreach (var entry in collection)
                action.Invoke(entry);

            return collection;
        }
    }
}
