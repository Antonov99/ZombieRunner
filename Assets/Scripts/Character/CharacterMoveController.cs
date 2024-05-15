using System;
using DefaultNamespace;
using UnityEngine;
using Zenject;

namespace Character
{
    public class CharacterMoveController : IInitializable, IDisposable
    {
        private InputSystem _inputSystem;

        private GameObject _character;
        
        private MoveComponent _moveComponent;

        [Inject]
        private void Construct(InputSystem inputSystem, PlayerService playerService)
        {
            _inputSystem = inputSystem;
            _character = playerService.Character;
        }
        
        public void Initialize()
        {
            _inputSystem.SwipeLeft += SwipeLeft;
            _inputSystem.SwipeRight += SwipeRight;
            _inputSystem.SwipeUp += SwipeUp;
            _inputSystem.SwipeDown += SwipeDown;
            
            _moveComponent = _character.GetComponent<MoveComponent>();
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
