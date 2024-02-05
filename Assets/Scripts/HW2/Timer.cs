using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _startTimer = 10f;
    [SerializeField] private Text _timerText;
    [SerializeField] private UnityEvent _onTimerOut;

    private float _currentTime;

    private IEnumerator coroutine;

    private void Start()
    {
        _currentTime = _startTimer + 1;

        coroutine = UpdateTimer();
        StartCoroutine(coroutine);
    }

    private IEnumerator UpdateTimer()
    {
        while (true)
        {
            _currentTime--;
            _timerText.text = "Timer: " + _currentTime.ToString();

            if (_currentTime == 0)
            {
                Time.timeScale = 0f;
                _onTimerOut.Invoke();
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
