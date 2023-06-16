using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class TransformAnglesExtensions
    {
        public static Transform SetWorldAngleX(this Transform transform, float value)
        {
            var current = transform.eulerAngles;
            current.x = value;
            transform.eulerAngles = current;
            return transform;
        }

        public static Transform SetWorldAngleY(this Transform transform, float value)
        {
            var current = transform.eulerAngles;
            current.y = value;
            transform.eulerAngles = current;
            return transform;
        }

        public static Transform SetWorldAngleZ(this Transform transform, float value)
        {
            var current = transform.eulerAngles;
            current.z = value;
            transform.eulerAngles = current;
            return transform;
        }

        public static Transform SetLocalAngleX(this Transform transform, float value)
        {
            var current = transform.localEulerAngles;
            current.x = value;
            transform.localEulerAngles = current;
            return transform;
        }

        public static Transform SetLocalAngleY(this Transform transform, float value)
        {
            var current = transform.localEulerAngles;
            current.y = value;
            transform.localEulerAngles = current;
            return transform;
        }

        public static Transform SetLocalAngleZ(this Transform transform, float value)
        {
            var current = transform.localEulerAngles;
            current.z = value;
            transform.localEulerAngles = current;
            return transform;
        }

        public static Transform SetWorldPosition(this Transform transform, Vector3 value)
        {
            transform.eulerAngles = value;
            return transform;
        }

        public static Transform SetLocalAngle(this Transform transform, Vector3 value)
        {
            transform.localEulerAngles = value;
            return transform;
        }

        public static Vector3 GetWorldAngles(this Transform transform)
        {
            return transform.eulerAngles;
        }

        public static Vector3 GetLocalAngles(this Transform transform)
        {
            return transform.localEulerAngles;
        }
    }
}