using UnityEditor;
using UnityEngine;

namespace BinaryEyes.Common.Components
{
    public class QuitOnEscape
        : MonoBehaviour
    {
        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape))
                return;

            enabled = false;
            Quit();
        }

        private void Quit()
        {
            Application.Quit();
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#endif
        }
    }
}