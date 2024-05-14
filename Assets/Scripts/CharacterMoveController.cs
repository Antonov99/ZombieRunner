using System;
using UnityEngine;
using Zenject;

public class CharacterMoveController : MonoBehaviour
{
    private InputSystem _inputSystem;
    private ushort _currentLine = 1;

    [SerializeField] 
    private Transform playerTransform;
    
    [SerializeField] 
    private float moveSpeed;

    [SerializeField] 
    private float lineWidth;
    
    private Vector3 _movementDirection;

    private String _direction;

    [Inject]
    private void Construct(InputSystem inputSystem)
    {
        _inputSystem = inputSystem;
        _inputSystem.SwipeLeft += SwipeLeft;
        _inputSystem.SwipeRight += SwipeRight;
        _inputSystem.SwipeUp += SwipeUp;
        _inputSystem.SwipeDown += SwipeDown;
        _movementDirection.z = moveSpeed;
    }

    private void Update()
    {
        _inputSystem.Update();
    }

    private void Swipe()
    {
        var position = playerTransform.position;
        Vector3 targetPosition = position.z * playerTransform.forward +
                                 position.y * playerTransform.up +
                                 position.x * playerTransform.right;
        if (_direction=="left")
            targetPosition += Vector3.left * lineWidth;
        else if (_direction=="right")
            targetPosition += Vector3.right * lineWidth;
        playerTransform.position = targetPosition;
        
        Debug.Log(_currentLine);
    }

    private void FixedUpdate()
    {
        Vector3 offset = _movementDirection * Time.deltaTime;
        playerTransform.position += offset;
    }

    private void SwipeLeft()
    {
        if (_currentLine > 0)
        {
            _direction = "left";
            _currentLine--;
            Swipe();
        }
    }

    private void SwipeRight()
    {
        if (_currentLine < 2)
        {
            _direction = "right";
            _currentLine++;
            Swipe();
        }
    }

    private void SwipeUp()
    {
    }
    
    private void SwipeDown()
    {
    }
}
