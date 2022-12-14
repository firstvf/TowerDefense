using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenu;
    private Image _PauseImage;
    private bool _isPauseON;

    private void Awake()
    {
        _isPauseON = false;
        _PauseImage = GetComponent<Image>();
    }

    public void PauseControl()
    {
        if (!_isPauseON)
        {
            _PauseImage.color = Color.gray;
            _pauseMenu.SetActive(true);
            _isPauseON = true;
            Time.timeScale = 0f;
        }
        else
        {

            _PauseImage.color = new Color(0.44f, 0.67f, 0.42f, 1);
            _pauseMenu.SetActive(false);
            _isPauseON = false;
            Time.timeScale = 1f;
        }
    }

    public void ResumeGame()
    {
        if (_isPauseON)
        {
            Time.timeScale = 1f;
            _isPauseON = false;
            _PauseImage.color = new Color(0.44f, 0.67f, 0.42f, 1);
            _pauseMenu.SetActive(false);
        }
    }
}