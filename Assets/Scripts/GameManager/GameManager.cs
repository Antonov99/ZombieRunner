using System;
using JetBrains.Annotations;

namespace GameManager
{
    [UsedImplicitly]
    public sealed class GameManager
    {
        public GameState State => _state;

        private GameState _state;

        public event Action OnStartGame; 
        public event Action OnPauseGame;
        public event Action OnResumeGame; 
        public event Action OnFinishGame; 
        public event Action OnExitGame; 

        public void StartGame()
        {
            _state = GameState.PLAYING;
            OnStartGame?.Invoke();
        }
        
        public void PauseGame()
        {
            _state = GameState.PAUSED;
            OnPauseGame?.Invoke();
        }
        
        public void ResumeGame()
        {
            _state = GameState.PLAYING;
            OnResumeGame?.Invoke();
        }

        public void FinishGame()
        {
            _state = GameState.FINISHED;
            OnFinishGame?.Invoke();
        }

        public void ExitMenu()
        {
            _state = GameState.OFF;
            OnExitGame?.Invoke();
        }
    }
}