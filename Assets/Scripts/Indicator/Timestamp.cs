using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timestamp : MonoBehaviour
{
    public int second, minute;
    private float timer;
    private UIManager uiManager;

    private void Start()
    {
        uiManager = FindAnyObjectByType<UIManager>();
    }

    private void Update()
    {
        CalculateTime();
    }

    void CalculateTime()
    {
        timer += Time.deltaTime;

        if (timer >= 1f)
        {
            timer = 0;
            second++;
        }

        if (second >= 60) 
        {
            second = 0;
            minute++;
        }

        UITime();
    }

    void UITime()
    {
        uiManager.timerUI.text = string.Format("{0:00}:{1:00}", minute, second);
    }
}
