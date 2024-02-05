using UnityEngine;

public class FinishZone : MonoBehaviour
{
    [SerializeField] private GameObject _youWinWindow;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _youWinWindow.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
