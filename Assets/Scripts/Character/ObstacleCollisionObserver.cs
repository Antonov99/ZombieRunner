using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Character
{
    [UsedImplicitly]
    public class ObstacleCollisionObserver : IInitializable, IDisposable
    {
        private CollisionHandler _collisionHandler;

        [Inject]
        public void Construct(CollisionHandler collisionHandler)
        {
            _collisionHandler = collisionHandler;
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
            Debug.Log("Udar");
        }
    }
}