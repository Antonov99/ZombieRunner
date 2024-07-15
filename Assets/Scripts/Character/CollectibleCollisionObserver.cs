using System;
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

        private void OnCollisionWithCollectible()
        {
            _moneyStorage.Add(1);
        }
    }
}