using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class TransformPositionExtensions
    {
        public static Transform SetWorldPositionX(this Transform transform, float value)
        {
            var current = transform.position;
            current.x = value;
            transform.position = current;
            return transform;
        }

        public static Transform SetWorldPositionY(this Transform transform, float value)
        {
            var current = transform.position;
            current.y = value;
            transform.position = current;
            return transform;
        }

        public static Transform SetWorldPositionZ(this Transform transform, float value)
        {
            var current = transform.position;
            current.z = value;
            transform.position = current;
            return transform;
        }

        public static Transform SetLocalPositionX(this Transform transform, float value)
        {
            var current = transform.localPosition;
            current.x = value;
            transform.localPosition = current;
            return transform;
        }

        public static Transform SetLocalPositionY(this Transform transform, float value)
        {
            var current = transform.localPosition;
            current.y = value;
            transform.localPosition = current;
            return transform;
        }

        public static Transform SetLocalPositionZ(this Transform transform, float value)
        {
            var current = transform.localPosition;
            current.z = value;
            transform.localPosition = current;
            return transform;
        }

        public static Transform SetWorldPosition(this Transform transform, Vector3 value)
        {
            transform.position = value;
            return transform;
        }

        public static Transform SetLocalPosition(this Transform transform, Vector3 value)
        {
            transform.localPosition = value;
            return transform;
        }

        public static Vector3 GetWorldPosition(this Transform transform)
        {
            return transform.position;
        }

        public static Vector3 GetLocalPosition(this Transform transform)
        {
            return transform.localPosition;
        }
    }
}