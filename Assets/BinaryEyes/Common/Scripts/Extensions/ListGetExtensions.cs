using System.Collections.Generic;

namespace BinaryEyes.Common.Extensions
{
    /// <summary>
    /// The ListGetExtensions class provides extension methods for collections
    /// related to item or other types of retrieval operations.
    /// </summary>
    public static class ListGetExtensions
    {
        public static List<T> GetShuffledClone<T>(this List<T> list)
        {
            var indexCollection = new List<int>(list.Count);
            for (var i = 0; i < list.Capacity; i++)
                indexCollection.Add(i);

            var clone = new List<T>(list.Count);
            while (indexCollection.Count > 0)
                clone.Add(list[indexCollection.PopRandom()]);

            return clone;
        }
    }
}
