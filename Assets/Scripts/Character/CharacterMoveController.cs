using System;
using DefaultNamespace;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Character
{
    [UsedImplicitly]
    public class CharacterMoveController : IInitializable, IDisposable
    {
        private InputSystem _inputSystem;

        private GameObject _character;
        
        private MoveComponent _moveComponent;

        private CollisionHandler _collisionHandler;

        [Inject]
        private void Construct(InputSystem inputSystem, PlayerService playerService, CollisionHandler collisionHandler)
        {
            _inputSystem = inputSystem;
            _character = playerService.Character;
            _collisionHandler = collisionHandler;
        }
        
        public void Initialize()
        {
            _inputSystem.SwipeLeft += SwipeLeft;
            _inputSystem.SwipeRight += SwipeRight;
            _inputSystem.SwipeUp += SwipeUp;
            _inputSystem.SwipeDown += SwipeDown;
            _collisionHandler.OnCollisionWithObstacle += OnCollisionWithObstacle;
            
            _moveComponent = _character.GetComponent<MoveComponent>();
        }

        private void OnCollisionWithObstacle()
        {
            _moveComponent.Dead();
        }

        public void Dispose()
        {
            _inputSystem.SwipeLeft -= SwipeLeft;
            _inputSystem.SwipeRight -= SwipeRight;
            _inputSystem.SwipeUp -= SwipeUp;
            _inputSystem.SwipeDown -= SwipeDown;
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
