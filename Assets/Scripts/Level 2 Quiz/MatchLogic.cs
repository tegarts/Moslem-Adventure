using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MatchLogic : MonoBehaviour
{
    static MatchLogic instance;

    public int maxPoints = 5;
    //public TMP_Text pointsText;
    public TMP_Text pointsRightText;
    public GameObject levelCompleteUI;
    private int dones = 0;
    private int points = 0;

    [Header("Door Logic")]
    private bool isInsideCol = false;
    public GameObject popupButton;
    public GameObject soalUI1;
    public GameObject pauseButton;
    // TODO - Tambahin playerstat buat ngurangin nyawa
    public bool isDone;

    private void Start()
    {
        instance = this;

        popupButton.SetActive(false);
        soalUI1.SetActive(false);
        levelCompleteUI.SetActive(false);
    }

    private void Update()
    {
        if(isInsideCol)
        {
            if(Input.GetKeyDown(KeyCode.Q))
            {
                soalUI1.SetActive(true);
                pauseButton.SetActive(false);
                isInsideCol = false;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            popupButton.SetActive(true);
            isInsideCol = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            popupButton.SetActive(false);
            isInsideCol = false;
        }
    }

    void UpdatePointsText()
    {
        //pointsText.text = points + "/" + maxPoints;
        if (dones == 5)
        {
            levelCompleteUI.SetActive(true);
            pointsRightText.text = points.ToString();
        }
    }

    public static void AddDone()
    {
        AddDones(1);
    }

    public static void AddDones(int dones)
    {
        instance.dones += dones;
        instance.UpdatePointsText();

    }

    public static void AddPoint()
    {
        AddPoints(20);
    }

    public static void AddPoints(int points)
    {
        instance.points += points;

    }
}
