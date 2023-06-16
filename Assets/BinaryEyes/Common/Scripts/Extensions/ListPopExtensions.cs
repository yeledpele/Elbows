using System.Collections.Generic;
using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    /// <summary>
    /// Extends the list object with common pop operations.
    /// </summary>
    public static class ListPopExtensions
    {
        public static T PopRandom<T>(this List<T> list)
        {
            var index = Random.Range(0, list.Count);
            return list.Pop(index);
        }

        public static T PopLast<T>(this List<T> list)
        {
            return list.Pop(list.Count - 1);
        }

        public static T PopFirst<T>(this List<T> list)
        {
            return list.Pop(0);
        }

        public static T Pop<T>(this List<T> list, int index)
        {
            var item = list[index];
            list.RemoveAt(index);

            return item;
        }
    }
}
