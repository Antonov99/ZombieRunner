using SceneNavigation;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace UI.StartScene
{
    public class StartMenuView:MonoBehaviour
    {
        [SerializeField]
        private Button playButton;
        
        [SerializeField]
        private Button exitButton;

        private SceneLoader _sceneLoader;

        [FormerlySerializedAs("scene")]
        [SerializeField]
        private string nameOfSceneToNavigate;

        [Inject]
        public void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            playButton.onClick.AddListener(LoadGame);
            exitButton.onClick.AddListener(QuitGame);
        }

        private void LoadGame()
        {
            _sceneLoader.LoadScene(nameOfSceneToNavigate);
        }

        private void QuitGame()
        {
            Application.Quit();
        }

        private void OnDisable()
        {
            playButton.onClick.RemoveListener(LoadGame);
            exitButton.onClick.RemoveListener(QuitGame);
        }
    }
}