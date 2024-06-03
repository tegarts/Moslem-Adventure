using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewQuiz : MonoBehaviour
{
    public GameObject[] questions = new GameObject[20];   
    private PlayerStat playerStat;
    public GameObject popUpBantuan;
    public GameObject popUpNoBantuan;
    public GameObject[] jawabanBantuan = new GameObject[20];
    public TMP_Text[] jumlahBantuanText;

    private void Start() 
    {
        playerStat = FindAnyObjectByType<PlayerStat>();
        popUpBantuan.SetActive(false);
        SetQuestionFalse();
    }

    private void Update() {
        for(int i = 0; i < jumlahBantuanText.Length; i++)
        {
            jumlahBantuanText[i].text = playerStat.playerBantuan.ToString();
        }
        
    }

    private void SetQuestionFalse()
    {
        for(int i = 0; i < questions.Length; i++)
        {
            questions[i].SetActive(false);
        }
    }

    public void NextNumber(int questionNumber)
    {
        playerStat.playerAnswered++;
        if(questionNumber % 2 == 1)
        {
            questions[questionNumber - 1].SetActive(false);
            questions[questionNumber].SetActive(true);
            
        }
        else
        {
            questions[questionNumber - 1].SetActive(false);
        }
    }

    public void NextRightChecker(bool isCorrect)
    {
        if(isCorrect)
            {
                playerStat.playerScore += 5;
            }
            else
            {
                playerStat.currentHealth -= 10;
            }
    }

    public void ButtonBantuan(int questionNumber)
    {
        if(playerStat.playerBantuan > 0)
        {
            for(int i = 0; i < jawabanBantuan.Length; i++)
        {
            jawabanBantuan[i].SetActive(false);
        }

        popUpBantuan.SetActive(true);
        jawabanBantuan[questionNumber - 1].SetActive(true);
        playerStat.playerBantuan--;
        }
        else
        {
            popUpNoBantuan.SetActive(true);
        }
    }
    
    public void BackButtonBantuan()
    {
        if(popUpBantuan.activeSelf)
        {
            popUpBantuan.SetActive(false);
        }
        else
        {
            popUpNoBantuan.SetActive(false);
        }
    }
    
}
