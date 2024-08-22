using TMPro;
using UnityEngine;

public class AccelerationButton : MonoBehaviour
{
    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void ChangeGameSpeedX1()
    {
        if (Time.timeScale != 1f)
            Time.timeScale = 1f;

    }

    public void ChangeGameSpeedX2()
    {
        if (Time.timeScale != 2f)
            Time.timeScale = 2f;
    }

    public void ChangeGameSpeedX3()
    {
        if (Time.timeScale != 3f)
            Time.timeScale = 3f;
    }
}