using JetBrains.Annotations;

namespace GameManager
{
    [UsedImplicitly]
    public sealed class GameManager
    {
        public GameState State => _state;

        private GameState _state;

        public void StartGame()
        {
            _state = GameState.PLAYING;
        }

        public void FinishGame()
        {
            _state = GameState.FINISHED;
        }
    }
}