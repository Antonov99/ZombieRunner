using System;
using Animators;
using JetBrains.Annotations;
using Zenject;

namespace Character
{
    [UsedImplicitly]
    public sealed class ObstacleCollisionObserver : IInitializable, IDisposable
    {
        private CollisionHandler _collisionHandler;
        private GameManager.GameManager _gameManager;
        private DeathAnimatorTrigger _deathAnimatorTrigger;

        [Inject]
        public void Construct(
            CollisionHandler collisionHandler, 
            GameManager.GameManager gameManager, 
            DeathAnimatorTrigger deathAnimatorTrigger
            )
        {
            _collisionHandler = collisionHandler;
            _gameManager = gameManager;
            _deathAnimatorTrigger = deathAnimatorTrigger;
        }

        void IInitializable.Initialize()
        {
            _collisionHandler.OnCollisionWithObstacle += OnCollisionWithObstacle;
        }
        
        void IDisposable.Dispose()
        {
            _collisionHandler.OnCollisionWithObstacle -= OnCollisionWithObstacle;
        }
        
        private void OnCollisionWithObstacle()
        {
            _deathAnimatorTrigger.Death();
            _gameManager.FinishGame();
        }
    }
}