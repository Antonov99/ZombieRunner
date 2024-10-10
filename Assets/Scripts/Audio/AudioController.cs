using System;
using JetBrains.Annotations;
using Zenject;

namespace Audio
{
    [UsedImplicitly]
    public sealed class AudioController:IInitializable, IDisposable
    {
        private GameManager.GameManager _gameManager;
        
        [Inject]
        public void Construct(GameManager.GameManager gameManager)
        {
            _gameManager = gameManager;
        }
        
        public void Initialize()
        {
            _gameManager.OnStartGame += StartGame;
            _gameManager.OnPauseGame += PauseGame;
            _gameManager.OnResumeGame += ResumeGame;
            _gameManager.OnFinishGame += FinishGame;
            _gameManager.OnExitGame += ExitGame;
        }

        private void StartGame()
        {
            AudioManager.Instance.PlayMainTheme();
        }

        private void PauseGame()
        {
            AudioManager.Instance.PlayPauseMenu();
        }

        private void ResumeGame()
        {
            AudioManager.Instance.PlayMainTheme();
        }

        private void FinishGame()
        {
            AudioManager.Instance.PlayGameOver();
        }
        
        private void ExitGame()
        {
            AudioManager.Instance.PlayStartMenu();
        }

        public void Dispose()
        {
            _gameManager.OnStartGame -= StartGame;
            _gameManager.OnPauseGame -= PauseGame;
            _gameManager.OnResumeGame -= ResumeGame;
            _gameManager.OnFinishGame -= FinishGame;
            _gameManager.OnExitGame -= ExitGame;
        }
    }
}