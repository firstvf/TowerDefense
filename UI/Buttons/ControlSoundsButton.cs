using UnityEngine;
using UnityEngine.UI;

public class ControlSoundsButton : MonoBehaviour
{
    private Image _buttonImage;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
    }

    public void ControlSounds()
    {
        if (GameData.IsDisableSounds == false)
        {
            GameData.DisableSounds();
            _buttonImage.color = Color.gray;
        }
        else
        {
            GameData.EnableSounds();
            _buttonImage.color = new Color(0.44f, 0.67f, 0.42f, 1);
        }
    }
}