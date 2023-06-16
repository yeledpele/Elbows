using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class Vector3SetExtensions
    {
        public static Vector3 SetX(this Vector3 current, float value)
        {
            current.x = value;
            return current;
        }
    }
}
