using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HwTouchInput : MonoBehaviour
{
    private Vector2 _startingPoint;
    private Vector2 _deltaPosition;
    
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            CheckRightSwipe();
        }

        if (Input.touchCount == 2)
        {
            CheckForEnhance();
        }
    }

    private void CheckRightSwipe()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            _startingPoint = touch.position;
        }

        if (touch.phase == TouchPhase.Ended)
        {
            _deltaPosition = touch.position - _startingPoint;
        }

        if (_deltaPosition.x >= 100 && Mathf.Abs(_deltaPosition.y) < 50)
        {
            Debug.Log("Right swipe detected");
            _deltaPosition = Vector2.zero;
        }
    }

    private void CheckForEnhance()
    {
        Touch touch1 = Input.GetTouch(0);
        Touch touch2 = Input.GetTouch(1);

        float startDistance = CalculateTouchDistance(touch1, touch2);
        float distance = CalculateTouchDistance(touch1, touch2);

        if (distance < startDistance)
        {
            Debug.Log("Decrease size detected");
        }
        if (distance > startDistance)
        {
            Debug.Log("Increase size detected");
        }

        if (touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended)
        {
            startDistance = 0f;
            distance = 0f;
        }
    }

    private float CalculateTouchDistance(Touch t1, Touch t2)
    {
        float deltaX = t1.position.x - t2.position.x;
        float deltaY = t1.position.y - t2.position.y;

        return Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }
}
