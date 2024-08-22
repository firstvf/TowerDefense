using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public void LoadMainMenu()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene(0);
    }
}