using System;
using UnityEngine;

public class InputSystem
{
    public event Action SwipeLeft;
    public event Action SwipeRight;
    public event Action SwipeUp;
    public event Action SwipeDown;
    
    public static bool tap;
    private bool _isDragging;
    private Vector2 _startTouch, _swipeDelta;

    public void Update()
    {
        #region ПК-версия

        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            _isDragging = true;
            _startTouch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
            Reset();
        }

        #endregion

        #region Мобильная версия

        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                _isDragging = true;
                _startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                _isDragging = false;
                Reset();
            }
        }

        #endregion

        _swipeDelta = Vector2.zero;
        if (_isDragging)
        {
            if (Input.touches.Length < 0)
                _swipeDelta = Input.touches[0].position - _startTouch;
            else if (Input.GetMouseButton(0))
                _swipeDelta = (Vector2)Input.mousePosition - _startTouch;
        }

        if (_swipeDelta.magnitude > 100)
        {
            float x = _swipeDelta.x;
            float y = _swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                    SwipeLeft?.Invoke();
                else
                    SwipeRight?.Invoke();
            }
            else
            {
                if (y < 0)
                    SwipeDown?.Invoke();
                else
                    SwipeUp?.Invoke();
            }

            Reset();
        }
    }

    private void Reset()
    {
        _startTouch = _swipeDelta = Vector2.zero;
        _isDragging = false;
    }
}