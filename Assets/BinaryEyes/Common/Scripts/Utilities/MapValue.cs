using BinaryEyes.Common.Data;
using BinaryEyes.Common.Extensions;

namespace BinaryEyes.Common.Utilities
{
    public static class MapValue
    {
        public static float Perform(float value, Interval source, Interval target)
        {
            value = source.GetLocked(value);
            var normalized = (value - source.Min) / (source.Max - source.Min);
            return target.Min + normalized * (target.Max - target.Min);
        }
    }
}
