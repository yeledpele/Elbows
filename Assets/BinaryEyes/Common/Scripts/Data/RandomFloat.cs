using System;

namespace BinaryEyes.Common.Data
{
    /// <summary>
    /// Responsible for generating a random floating point value from some base
    /// modified by a particular interval.
    /// </summary>
    [Serializable]
    public class RandomFloat
    {
        public float Base;
        public Interval Range;
        public float GetRandom() => Base + Range.GetRandom();
    }
}
