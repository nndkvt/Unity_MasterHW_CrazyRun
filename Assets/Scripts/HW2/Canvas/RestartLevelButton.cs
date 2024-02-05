using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevelButton : MonoBehaviour
{
    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
