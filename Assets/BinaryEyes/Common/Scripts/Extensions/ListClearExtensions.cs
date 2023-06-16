using System.Collections.Generic;

namespace BinaryEyes.Common.Extensions
{
    public static class ListClearExtensions
    {
        public static List<T> ClearList<T>(this List<T> list)
        {
            list.Clear();
            return list;
        }
    }
}
