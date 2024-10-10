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

        [FormerlySerializedAs("scene")]
        [SerializeField]
        private string nameOfSceneToNavigate;

        private SceneLoader _sceneLoader;
        private GameManager.GameManager _gameManager;

        [Inject]
        public void Construct(SceneLoader sceneLoader, GameManager.GameManager gameManager)
        {
            _sceneLoader = sceneLoader;
            _gameManager = gameManager;
        }

        private void Awake()
        {
            playButton.onClick.AddListener(LoadGame);
            exitButton.onClick.AddListener(QuitGame);
        }

        private void LoadGame()
        {
            _sceneLoader.LoadScene(nameOfSceneToNavigate);
            _gameManager.StartGame();
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