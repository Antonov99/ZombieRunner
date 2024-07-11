using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Character
{
    [UsedImplicitly]
    public sealed class CollectibleCollisionObserver : IInitializable, IDisposable
    {
        private CollisionHandler _collisionHandler;

        [Inject]
        public void Construct(CollisionHandler collisionHandler)
        {
            _collisionHandler = collisionHandler;
        }

        void IInitializable.Initialize()
        {
            _collisionHandler.OnCollisionWithCollectible += OnCollisionWithCollectible;
        }

        void IDisposable.Dispose()
        {
            _collisionHandler.OnCollisionWithCollectible -= OnCollisionWithCollectible;
        }

        private void OnCollisionWithCollectible()
        {
            Debug.Log("Collect");
        }
    }
}