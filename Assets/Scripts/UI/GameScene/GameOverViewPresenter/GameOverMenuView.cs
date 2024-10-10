using SceneNavigation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.GameScene
{
    public class GameOverMenuView:MonoBehaviour
    {
        [SerializeField]
        private Button playButton;
        
        [SerializeField]
        private Button exitButton;
        
        [SerializeField]
        private TextMeshProUGUI scoreText;
        
        [SerializeField]
        private GameObject gameOverMenu;
        
        private SceneLoader _sceneLoader;
        private GameManager.GameManager _gameManager;
        
        [Inject]
        public void Construct(SceneLoader sceneLoader, GameManager.GameManager gameManager)
        {
            _sceneLoader = sceneLoader;
            _gameManager = gameManager;
        }

        private void Start()
        {
            playButton.onClick.AddListener(Restart);
            exitButton.onClick.AddListener(Exit);
        }

        public void UpdateScore(string score)
        {
            scoreText.text = score;
        }

        private void Restart()
        {
            _sceneLoader.LoadScene("Game");
            _gameManager.StartGame();
        }

        private void Exit()
        {
            _sceneLoader.LoadScene("StartMenu");
            _gameManager.ExitMenu();
        }

        public void GameOver()
        {
            SetActive(gameOverMenu,true);
        }
        
        private void SetActive(GameObject obj, bool value)
        {
            obj.SetActive(value);    
        }
        
        private void OnDestroy()
        {
            playButton.onClick.RemoveListener(Restart);
            exitButton.onClick.RemoveListener(Exit);
        }
    }
}