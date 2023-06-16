using System;
using Random = UnityEngine.Random;

namespace BinaryEyes.Common.Data
{
    /// <summary>
    /// Describes a range of integer values.
    /// </summary>
    [Serializable]
    public struct Range
    {
        public int Min;
        public int Max;
        public int Length => Max - Min;
        public bool Contains(int value) => Min <= value && value <= Max;
        public int GetRandom() => Random.Range(Min, Max);

        public Range(int value)
            : this(-value, +value)
        {

        }

        public Range(int min, int max)
        {
            Min = min;
            Max = max;
        }

        public static Range operator +(Range lhs, Range rhs) => new(lhs.Min + rhs.Min, lhs.Max + rhs.Max);
        public static Range operator -(Range lhs, Range rhs) => new(lhs.Min - rhs.Min, lhs.Max - rhs.Max);
        public static Range operator *(Range lhs, Range rhs) => new(lhs.Min*rhs.Min, lhs.Max*rhs.Max);
        public static Range operator *(Range lhs, int rhs) => new(lhs.Min*rhs, lhs.Max*rhs);
        public static Range operator *(int lhs, Range rhs) => new(lhs*rhs.Min, lhs*rhs.Max);
        public static Range operator /(Range lhs, Range rhs) => new(lhs.Min/rhs.Min, lhs.Max/rhs.Max);
        public static Range operator /(Range lhs, int rhs) => new(lhs.Min/rhs, lhs.Max/rhs);
    }
}
