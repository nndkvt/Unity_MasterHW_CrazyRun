using UnityEngine;
using UnityEngine.UI;

public class Hw2TouchInput : MonoBehaviour
{
    [SerializeField] private Image _startingPoint;
    [SerializeField] private Rigidbody _sphereRB;
    [SerializeField] private float _speed = 10f;

    // Update is called once per frame
    private void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 pos = new Vector3(touch.deltaPosition.x, 0f, touch.deltaPosition.y);
            _sphereRB.AddForce(pos * _speed);

            if (touch.phase == TouchPhase.Began)
            {
                CreateStartingPoint(touch);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                DisableStartingPoint();
            }
        }
    }

    private void CreateStartingPoint(Touch _touch)
    {
        _startingPoint.transform.position = new Vector3(_touch.position.x, _touch.position.y, 0f);
        _startingPoint.gameObject.SetActive(true);
    }

    private void DisableStartingPoint()
    {
        _startingPoint.gameObject.SetActive(false);
    }
}
