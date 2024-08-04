using SceneNavigation;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.GameScene
{
    public class InterfaceView : MonoBehaviour
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

        [Inject]
        public void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
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
        }

        private void PauseGame()
        {
            SetActive(_pauseButtonGameObject,false);
            SetActive(pauseMenu,true);
            Time.timeScale = 0;
        }
        
        private void ResumeGame()
        {
            SetActive(_pauseButtonGameObject,true);
            SetActive(pauseMenu,false);
            Time.timeScale = 1;
        }
        
        private void SetActive(GameObject obj, bool value)
        {
            obj.SetActive(value);    
        }

        private void OnDisable()
        {
            pauseButton.onClick.RemoveListener(PauseGame);
            resumeButton.onClick.RemoveListener(ResumeGame);
            exitButton.onClick.RemoveListener(ExitGame);
        }
    }
}