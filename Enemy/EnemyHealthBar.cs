using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private GameObject _canvas;
    private Enemy _enemy;
    private float _maxHealth;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
        _maxHealth = _enemy.Health;
    }

    public void UpdateHealthBar(float health)
    {
        if (!_canvas.activeInHierarchy)
            _canvas.SetActive(true);
        _healthBar.fillAmount = health / _maxHealth;
    }

    private void RotationHealhBar()
    {

    }
}
