using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class MoveComponent:MonoBehaviour
    {
        [SerializeField]
        private Transform playerTransform;
        
        [SerializeField] 
        private float moveSpeed;
        
        [SerializeField] 
        private float lineWidth;
        
        private ushort _currentLine = 1;

        private Vector3 _movementDirection;

        private String _direction;

        private void Start()
        {
            _movementDirection.z = moveSpeed;
        }
        
        private void FixedUpdate()
        {
            Vector3 offset = _movementDirection * Time.deltaTime;
            playerTransform.position += offset;
        }
        
        private void Swipe()
        {
            var position = playerTransform.position;
            Vector3 targetPosition = position.z * playerTransform.forward +
                                     position.y * playerTransform.up +
                                     position.x * playerTransform.right;
            if (_direction == "left")
                targetPosition += Vector3.left * lineWidth;
            else if (_direction == "right")
                targetPosition += Vector3.right * lineWidth;
            playerTransform.position = targetPosition;

            Debug.Log(_currentLine);
        }
        
        public void SwipeLeft()
        {
            if (_currentLine > 0)
            {
                _direction = "left";
                _currentLine--;
                Swipe();
            }
        }

        public void SwipeRight()
        {
            if (_currentLine < 2)
            {
                _direction = "right";
                _currentLine++;
                Swipe();
            }
        }

        public void SwipeUp()
        {
        }

        public void SwipeDown()
        {
        }
    }
}