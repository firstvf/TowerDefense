using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlParticlesButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Image _buttonImage;

    private void Awake()
    {
        _buttonImage = GetComponent<Image>();
    }

    public void ControlParticles()
    {
        if (GameData.IsDisableParticles == false)
        {
            GameData.DisableParticles();
            _text.color = Color.gray;
            _buttonImage.color = Color.gray;
        }
        else
        {
            GameData.EnableParticles();
            _text.color = new Color(0.44f, 0.67f, 0.42f, 1);
            _buttonImage.color = new Color(0.44f, 0.67f, 0.42f, 1);
        }
    }
}