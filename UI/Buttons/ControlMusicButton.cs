using UnityEngine;
using UnityEngine.UI;

public class ControlMusicButton : MonoBehaviour
{
    private Image _buttonImage;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
    }

    public void ControlMusic()
    {
        if (GameData.IsDisableMusic == false)
        {
            GameData.DisableMusic();
            _buttonImage.color = Color.gray;
        }
        else
        {
            GameData.EnableMusic();
            _buttonImage.color = new Color(0.44f, 0.67f, 0.42f, 1);
        }
        Camera.main.GetComponent<BackGroundMusic>().ControlMusic();
    }
}