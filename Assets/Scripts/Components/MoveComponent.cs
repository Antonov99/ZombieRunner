using System;
using UnityEngine;

namespace Components
{
    public class MoveComponent:MonoBehaviour
    {
        [SerializeField]
        private Transform playerTransform;
        
        [SerializeField] 
        private float moveSpeed;

        [SerializeField] 
        private float jumpStrength;

        [SerializeField]
        private float gravity;
        
        [SerializeField] 
        private float lineWidth;
        
        private ushort _currentLine = 1;
        private Vector3 _movementDirection;
        private String _direction;
        private bool _isJumping;
        private bool _isDead;

        private void Awake()
        {
            _movementDirection.z = moveSpeed;
        }
        
        private void FixedUpdate()
        {
            if(_isDead) _movementDirection=Vector3.zero;
            Vector3 offset = _movementDirection * Time.deltaTime;
            playerTransform.position += offset;
            Gravity();
        }

        private void Gravity()
        {
            if (_isJumping)
            {
                _movementDirection.y -= gravity;
                if (playerTransform.position.y <= 0)
                {
                    _isJumping=false;
                    var position = playerTransform.position;
                    position = new Vector3(position.x, 0, position.z);
                    playerTransform.position = position;
                    _movementDirection.y = 0;
                }
            }
        }

        private void Swipe()
        {
            if(_isDead) return;
            var position = playerTransform.position;
            Vector3 targetPosition = position.z * playerTransform.forward +
                                     position.y * playerTransform.up +
                                     position.x * playerTransform.right;
            if (_direction == "left")
                targetPosition += Vector3.left * lineWidth;
            else if (_direction == "right")
                targetPosition += Vector3.right * lineWidth;
            playerTransform.position = targetPosition;
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
            if (!_isJumping)
            {
                _movementDirection.y = jumpStrength;
                _isJumping = true;
            }
        }

        public void SwipeDown()
        {
        }

        public void Dead()
        {
            _isDead = true;
        }
    }
}