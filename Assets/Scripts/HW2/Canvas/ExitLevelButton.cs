using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevelButton : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
