using UnityEngine;
using UnityEngine.SceneManagement;

namespace BinaryEyes.Common.Components
{
    public class LoadScene
        : MonoBehaviour
    {
        public string NextScene;
        public LoadSceneMode Mode;

        public void LoadSetScene()
            => LoadNextScene(NextScene, Mode);

        public void LoadNextScene(string nextScene, LoadSceneMode mode)
            => SceneManager.LoadScene(nextScene, mode);
    }
}
