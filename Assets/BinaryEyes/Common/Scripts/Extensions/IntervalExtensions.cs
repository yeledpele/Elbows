using BinaryEyes.Common.Data;

namespace BinaryEyes.Common.Extensions
{
    /// <summary>
    /// The IntervalExtensions contains extension methods to the interval
    /// structure providing common operations.
    /// </summary>
    public static class IntervalExtensions
    {
        public static float GetLocked(this Interval interval, float value)
        {
            return value < interval.Min ? interval.Min
                 : value > interval.Max ? interval.Max
                 : value;
        }
    }
}
