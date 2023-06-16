using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    /// <summary>
    /// Extends the base component class with common setters.
    /// </summary>
    public static class ComponentSetExtensions
    {
        public static T SetEnabled<T>(this T source, bool value) where T : MonoBehaviour
        {
            source.enabled = value;
            return source;
        }

        public static T SetName<T>(this T source, string value) where T : Component
        {
            source.name = value;
            return source;
        }

        public static Collider SetEnabled(this Collider collider, bool value)
        {
            collider.enabled = value;
            return collider;
        }

        public static Camera SetEnabled(this Camera camera, bool value)
        {
            camera.enabled = value;
            return camera;
        }
    }
}
