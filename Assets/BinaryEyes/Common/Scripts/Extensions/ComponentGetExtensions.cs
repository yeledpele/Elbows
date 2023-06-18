using System.Linq;
using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    public static class ComponentGetExtensions
    {
        public static T GetNameComponent<T>(this Component source, string name)
            where T : Component
        {
            var targets = source.GetComponentsInChildren<T>(true);
            return targets.FirstOrDefault(entry => entry.name == name);
        }
    }
}
