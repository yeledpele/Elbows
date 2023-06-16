using BinaryEyes.Common.Extensions;
using UnityEditor;

namespace BinaryEyes.Common.MenuItems
{
    /// <summary>
    /// Provides a menu item for resetting the local data of all selected transforms.
    /// </summary>
    public static class ResetSelectedTransforms
    {
        [MenuItem("Binary Eyes/Scene/Reset Selected Transforms")]
        public static void Perform()
        {
            Undo.RecordObjects(Selection.transforms, "ResetSelectedTransforms");
            foreach (var entry in Selection.transforms)
                entry.ResetLocal();
        }
    }
}
