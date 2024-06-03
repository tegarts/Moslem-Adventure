using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionEnemy : MonoBehaviour
{
    private HealthEnemy healthEnemy;
    private NewQuiz newQuiz;
    public int enemyNumber;

    private void Start() 
    {
        healthEnemy = GetComponentInChildren<HealthEnemy>();
        newQuiz = FindAnyObjectByType<NewQuiz>();
    }

    private void Update() 
    {
        if(healthEnemy.enemyHealth <= 0 && enemyNumber == 1)
        {
            newQuiz.questions[0].SetActive(true);
        }
        else if(healthEnemy.enemyHealth <= 0 && enemyNumber == 2)
        {
            newQuiz.questions[2].SetActive(true);
        }
        else if(healthEnemy.enemyHealth <= 0 && enemyNumber == 3)
        {
            newQuiz.questions[4].SetActive(true);
        }
        else if(healthEnemy.enemyHealth <= 0 && enemyNumber == 4)
        {
            newQuiz.questions[6].SetActive(true);
        }
        else if(healthEnemy.enemyHealth <= 0 && enemyNumber == 5)
        {
            newQuiz.questions[8].SetActive(true);
        }
        else if(healthEnemy.enemyHealth <= 0 && enemyNumber == 6)
        {
            newQuiz.questions[10].SetActive(true);
        }
        else if(healthEnemy.enemyHealth <= 0 && enemyNumber == 7)
        {
            newQuiz.questions[12].SetActive(true);
        }
        else if(healthEnemy.enemyHealth <= 0 && enemyNumber == 8)
        {
            newQuiz.questions[14].SetActive(true);
        }
        else if(healthEnemy.enemyHealth <= 0 && enemyNumber == 9)
        {
            newQuiz.questions[16].SetActive(true);
        }
        else if(healthEnemy.enemyHealth <= 0 && enemyNumber == 10)
        {
            newQuiz.questions[18].SetActive(true);
        }
    }
}
