using System;
using Components;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Character
{
    [UsedImplicitly]
    public class CharacterMoveController : IInitializable, IDisposable
    {
        private InputSystem.InputSystem _inputSystem;

        private GameObject _character;
        
        private MoveComponent _moveComponent;

        private CollisionHandler _collisionHandler;

        [Inject]
        private void Construct(InputSystem.InputSystem inputSystem, PlayerService playerService, CollisionHandler collisionHandler)
        {
            _inputSystem = inputSystem;
            _character = playerService.Character;
            _collisionHandler = collisionHandler;
            
            _moveComponent = _character.GetComponent<MoveComponent>();
        }

        void IInitializable.Initialize()
        {
            _inputSystem.SwipeLeft += SwipeLeft;
            _inputSystem.SwipeRight += SwipeRight;
            _inputSystem.SwipeUp += SwipeUp;
            _inputSystem.SwipeDown += SwipeDown;
            _collisionHandler.OnCollisionWithObstacle += OnCollisionWithObstacle;
        }

        void IDisposable.Dispose()
        {
            _inputSystem.SwipeLeft -= SwipeLeft;
            _inputSystem.SwipeRight -= SwipeRight;
            _inputSystem.SwipeUp -= SwipeUp;
            _inputSystem.SwipeDown -= SwipeDown;
            _collisionHandler.OnCollisionWithObstacle -= OnCollisionWithObstacle;
        }

        private void OnCollisionWithObstacle()
        {
            _moveComponent.Dead();
        }


        private void SwipeLeft()
        {
            _moveComponent.SwipeLeft();
        }

        private void SwipeRight()
        {
            _moveComponent.SwipeRight();
        }

        private void SwipeUp()
        {
            _moveComponent.SwipeUp();
        }

        private void SwipeDown()
        {
            _moveComponent.SwipeDown();
        }
    }
}
