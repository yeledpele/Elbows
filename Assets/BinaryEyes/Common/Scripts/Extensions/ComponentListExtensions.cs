using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class ComponentListExtensions
    {
        public static T[] Toggle<T>(this T[] components, bool isActive) where T : Component
            => components.ForEach(entry => entry.gameObject.SetActive(isActive));
    }
}
