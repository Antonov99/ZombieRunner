using System;
using Audio;
using JetBrains.Annotations;
using Money;
using UnityEngine;
using Zenject;

namespace UI.GameScene
{
    [UsedImplicitly]
    public class GameOverMenuPresenter:IGameOverMenuPresenter, IDisposable
    {
        private IMoneyStorage _moneyStorage;
        private GameOverMenuView _gameOverView;
        private GameManager.GameManager _gameManager;
        
        [Inject]
        public void Construct(IMoneyStorage moneyStorage, GameOverMenuView view, GameManager.GameManager gameManager)
        {
            _moneyStorage = moneyStorage;
            _gameOverView = view;
            _gameManager = gameManager;

            _gameManager.OnFinishGame += OnFinishGame;
        }

        private void OnFinishGame()
        {
            AudioManager.Instance.PlayGameOver();
            string text = "Your Score: " + _moneyStorage.Money;
            _gameOverView.UpdateScore(text);
            _gameOverView.GameOver();
        }

        void IDisposable.Dispose()
        {
            _gameManager.OnFinishGame -= OnFinishGame;
        }
    }
}