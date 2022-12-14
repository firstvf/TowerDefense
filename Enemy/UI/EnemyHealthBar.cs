using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private GameObject _canvas;
    [SerializeField] private TextMeshProUGUI _text;
    private Camera _mainCamera;
    private Enemy _enemy;
    private float _maxHealth;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        _mainCamera = Camera.main;
        _maxHealth = _enemy.Health;
        _text.text = _enemy.Health.ToString();
        RotationHealthBar();
    }

    public void UpdateHealthBar(int health)
    {
        if (!_canvas.activeInHierarchy)
            _canvas.SetActive(true);
        _healthBar.fillAmount = health / _maxHealth;
        UpdateTextHealth(health);
    }

    private void UpdateTextHealth(int hp)
    {
        _text.text = hp.ToString();
    }

    public void RotationHealthBar()
    {
        _canvas.transform.LookAt(_mainCamera.transform.position);
    }
}