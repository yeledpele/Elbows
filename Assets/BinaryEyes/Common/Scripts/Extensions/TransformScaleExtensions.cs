using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class TransformScaleExtensions
    {
        public static Transform SetLocalScaleX(this Transform transform, float value)
        {
            var current = transform.localScale;
            current.x = value;
            transform.localScale = current;
            return transform;
        }

        public static Transform SetLocalScaleY(this Transform transform, float value)
        {
            var current = transform.localScale;
            current.y = value;
            transform.localScale = current;
            return transform;
        }

        public static Transform SetLocalScaleZ(this Transform transform, float value)
        {
            var current = transform.localScale;
            current.z = value;
            transform.localScale = current;
            return transform;
        }

        public static Transform SetLocalScale(this Transform transform, Vector3 value)
        {
            transform.localScale = value;
            return transform;
        }

        public static Vector3 GetWorldScale(this Transform transform)
        {
            return transform.lossyScale;
        }

        public static Vector3 GetLocalAngles(this Transform transform)
        {
            return transform.localScale;
        }
    }
}