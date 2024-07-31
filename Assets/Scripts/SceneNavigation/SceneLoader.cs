using UnityEngine.SceneManagement;

namespace SceneNavigation
{
    public class SceneLoader
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}