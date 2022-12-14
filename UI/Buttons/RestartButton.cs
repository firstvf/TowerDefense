using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartGame()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
        }
        GameData.ClearAllData();
        SceneManager.LoadScene(1);
    }
}