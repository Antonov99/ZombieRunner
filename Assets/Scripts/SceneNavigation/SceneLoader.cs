using JetBrains.Annotations;
using UnityEngine.SceneManagement;

namespace SceneNavigation
{
    [UsedImplicitly]
    public class SceneLoader
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}