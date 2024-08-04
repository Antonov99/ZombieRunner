using System;
using Collectibles;
using Money;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Character
{
    [UsedImplicitly]
    public sealed class CollectibleCollisionObserver : IInitializable, IDisposable
    {
        private CollisionHandler _collisionHandler;
        private IMoneyStorage _moneyStorage;

        [Inject]
        public void Construct(CollisionHandler collisionHandler, IMoneyStorage moneyStorage)
        {
            _collisionHandler = collisionHandler;
            _moneyStorage = moneyStorage;
        }

        void IInitializable.Initialize()
        {
            _collisionHandler.OnCollisionWithCollectible += OnCollisionWithCollectible;
        }

        void IDisposable.Dispose()
        {
            _collisionHandler.OnCollisionWithCollectible -= OnCollisionWithCollectible;
        }

        private void OnCollisionWithCollectible(GameObject obj)
        {
            if (obj.TryGetComponent(out ICollectible collectible)) collectible.Collect(_moneyStorage);
        }
    }
}