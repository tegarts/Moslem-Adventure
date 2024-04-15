using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class FinishFlag : MonoBehaviour, IDataPersistence
{
    private FuzzyLogic fuzzyLogic;

    public GameObject panelFinish;
    public int currentLevel;
    private int coinReward;
    private int healthReward;
    private int bulletReward;

    public TMP_Text mainLagiButton;

    [Header("Bintang & Reward")]
    public List<GameObject> reward = new();
    public List<GameObject> star = new();
    public TMP_Text textWinLose;
    [SerializeField] private int levelUnlocked = 0;
    [SerializeField] private bool isGivingReward = false;

    public void LoadData(GameData data)
    {
        levelUnlocked = data.levelUnlocked;
    }

    public void SaveData(ref GameData data)
    {
        data.coin += coinReward;
        data.levelUnlocked = levelUnlocked;
        data.healthAdded = healthReward;
        data.bulletAdded = bulletReward;
    }

    private void Start()
    {
        fuzzyLogic = FindAnyObjectByType<FuzzyLogic>();
        panelFinish.SetActive(false);

        for(int i = 0; i < star.Count; i++)
        {
            star[i].SetActive(false);
            reward[i].SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            //fuzzyLogic.isFinish = true;
            panelFinish.SetActive(true);
            isGivingReward = true;
            Time.timeScale = 0f;
            AudioManager.instance.PlayMusic("menang");

        }
    }

    private void Update()
    {
        UIRewards();
        GivingReward();
    }

    private void UIRewards()
    {
        if (fuzzyLogic.hasilAkhir > 4.0f && fuzzyLogic.hasilAkhir <= 5.0f)
        {
            for (int i = 0; i < star.Count; i++)
            {
                star[i].SetActive(true);
                textWinLose.text = "KAMU MENANG";
            }

            for (int j = 0; j < reward.Count; j++)
            {
                reward[j].SetActive(false);
            }
            reward[4].SetActive(true);

        }
        else if (fuzzyLogic.hasilAkhir > 3.0f && fuzzyLogic.hasilAkhir <= 4.0f)
        {
            for (int i = 0; i < star.Count - 1; i++)
            {
                star[i].SetActive(true);
                textWinLose.text = "KAMU KALAH";
            }

            for (int j = 0; j < reward.Count; j++)
            {
                reward[j].SetActive(false);
            }
            reward[3].SetActive(true);
        }
        else if (fuzzyLogic.hasilAkhir > 2.0f && fuzzyLogic.hasilAkhir <= 3.0f)
        {
            for (int i = 0; i < star.Count - 2; i++)
            {
                star[i].SetActive(true);
                textWinLose.text = "KAMU KALAH";
            }

            for (int j = 0; j < reward.Count; j++)
            {
                reward[j].SetActive(false);
            }
            reward[2].SetActive(true);
        }
        else if (fuzzyLogic.hasilAkhir > 1.0f && fuzzyLogic.hasilAkhir <= 2.0f)
        {
            for (int i = 0; i < star.Count - 3; i++)
            {
                star[i].SetActive(true);
                textWinLose.text = "KAMU KALAH";
            }

            for (int j = 0; j < reward.Count; j++)
            {
                reward[j].SetActive(false);
            }
            reward[1].SetActive(true);
        }
        else if (fuzzyLogic.hasilAkhir > 0.0f && fuzzyLogic.hasilAkhir <= 1.0f)
        {
            star[0].SetActive(true);
            textWinLose.text = "KAMU KALAH";

            for (int j = 0; j < reward.Count; j++)
            {
                reward[j].SetActive(false);
            }
            reward[0].SetActive(true);
        }
        else
        {
            Debug.LogWarning("Hasil akhir Fuzzy bukan angka 1-5");
        }
    }

    private void GivingReward()
    {
        
      if(isGivingReward)
        {
            if (fuzzyLogic.hasilAkhir >= 5)
            {
                coinReward = 80;
                bulletReward = 50;
                healthReward = 5;

                if (currentLevel == 1)
                {
                    if(levelUnlocked < 1)
                    {
                        levelUnlocked = 1;
                    }
                }
                else if (currentLevel == 2)
                {
                    if(levelUnlocked < 2)
                    {
                        levelUnlocked = 2;
                    }
                }
                else if (currentLevel == 3)
                {
                    if(levelUnlocked < 3)
                    {
                        levelUnlocked = 3;
                    }
                }
                else if (currentLevel == 4)
                {
                    if(levelUnlocked < 4)
                    {
                        levelUnlocked = 4;
                    }
                }
                else if (currentLevel == 5)
                {
                    if(levelUnlocked < 4)
                    levelUnlocked = 4;
                }
            }
            else if (fuzzyLogic.hasilAkhir >= 4)
            {
                coinReward = 50;
                healthReward = 3;
            }
            else if (fuzzyLogic.hasilAkhir >= 3)
            {
                coinReward = 50;
            }
            else if (fuzzyLogic.hasilAkhir >= 2)
            {
                bulletReward = 25;
            }
            else if (fuzzyLogic.hasilAkhir <= 1)
            {
                healthReward = 3;
            }
        }
    }
}
