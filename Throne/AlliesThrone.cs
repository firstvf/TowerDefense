using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AlliesThrone : MonoBehaviour
{
    public int Health { get; private set; }
    public static AlliesThrone Singleton { get; private set; }

    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private GameObject _looserText;

    private void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        Health = 25;
        _healthText.text = Health.ToString();
    }

    public void ChangeHealth()
    {
        if (Health > 0)
        {
            Health--;
            ChangeHealthText();
        }
        if (Health == 0)
        {
            _looserText.SetActive(true);
            StartCoroutine(TimeBeforeEndGame());
        }
    }
    private IEnumerator TimeBeforeEndGame()
    {
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(2);
    }

    private void ChangeHealthText()
    {
        _healthText.text = Health.ToString();
    }
}