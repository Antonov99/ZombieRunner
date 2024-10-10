using SceneNavigation;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.GameScene
{
    public class PauseMenuView : MonoBehaviour
    {
        [SerializeField]
        private Button pauseButton;
        
        [SerializeField]
        private Button resumeButton;
        
        [SerializeField]
        private Button exitButton;

        [SerializeField]
        private GameObject pauseMenu;

        private GameObject _pauseButtonGameObject;

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
            _pauseButtonGameObject = pauseButton.gameObject;
            
            ResumeGame();
        }

        private void Start()
        {
            pauseButton.onClick.AddListener(PauseGame);
            resumeButton.onClick.AddListener(ResumeGame);
            exitButton.onClick.AddListener(ExitGame);
        }

        private void ExitGame()
        {
            _sceneLoader.LoadScene("StartMenu");
            _gameManager.ExitMenu();
        }

        private void PauseGame()
        {
            SetActive(_pauseButtonGameObject,false);
            SetActive(pauseMenu,true);
            Time.timeScale = 0;
            _gameManager.PauseGame();
        }
        
        private void ResumeGame()
        {
            SetActive(_pauseButtonGameObject,true);
            SetActive(pauseMenu,false);
            Time.timeScale = 1;
            _gameManager.ResumeGame();
        }
        
        private void SetActive(GameObject obj, bool value)
        {
            obj.SetActive(value);    
        }

        private void OnDestroy()
        {
            pauseButton.onClick.RemoveListener(PauseGame);
            resumeButton.onClick.RemoveListener(ResumeGame);
            exitButton.onClick.RemoveListener(ExitGame);
        }
    }
}