using UnityEditor;

namespace BinaryEyes.Common.MenuItems
{
    /// <summary>
    /// The ToggleSelectedGameObjects class provides a menu item for toggling
    /// the active state of all selected game objects in the scene.
    /// </summary>
    public static class ToggleSelectedGameObjects
    {
        public static void Perform()
        {
            Undo.RecordObjects(Selection.gameObjects, "ToggleSelectedGameObjects");
            foreach (var entry in Selection.gameObjects)
                entry.SetActive(!entry.activeSelf);
        }
    }
}
