using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clue : MonoBehaviour
{
    public GameObject popUp;
    public GameObject cluePanel;
    private bool isInside;
    public int clueCountValue;
    public int timerValue;
    private bool isQPressed;
    private Coroutine timerCoroutine;

    [Header("UI")]
    public TMP_Text clueCount;
    public TMP_Text timer;

    private void Start() 
    {
        popUp.SetActive(false);
        cluePanel.SetActive(false);
        clueCountValue = 3;
    }
    private void Update()
    {
        if(isInside && !isQPressed)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                if(clueCountValue > 0)
                {
                    clueCountValue--;
                    timerValue = 15;
                    isQPressed = true;
                    cluePanel.SetActive(true);
                    timerCoroutine = StartCoroutine(Timer());                    
                }
            }
        }

        clueCount.text = clueCountValue + "/3";
        
    }

    public void BackButton()
    {
        cluePanel.SetActive(false);
        isQPressed = false;
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInside = true;
            if(clueCountValue > 0)
                {
                    popUp.SetActive(true);
                }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            popUp.SetActive(false);
            isInside = false;
        }
    }

    private IEnumerator Timer()
    {
        while (timerValue > 0)
        {
            yield return new WaitForSeconds(1f);
            timerValue--;
            timer.text = timerValue.ToString();
        }

        cluePanel.SetActive(false);
        isQPressed = false;
        
    }
}
