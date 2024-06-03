using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text timerUI;
    public TMP_Text playerHealthUI;
    public Slider playerHealthSlider;
    public TMP_Text coinUI;
    public TMP_Text bulletUI;
    public TMP_Text keyUI;
    public TMP_Text enemyCount;
    public TMP_Text playerScoreUI;
    public TMP_Text playerAnsweredUI;
    public TMP_Text playerBantuanUI;

    private PlayerStat playerStat;
    private PlayerAttack playerAttack;
    private Timestamp timestamp;

    public GameObject pauseMenu;
    public GameObject gameOverPanel;
    private FuzzyLogic fuzzyLogic;
    private EnemyManager enemyManager;

    public TMP_Text mainLagiButton;

    public TMP_Text sisaNyawa, koinDikumpulkan, skorQuiz, waktuAkhir;
    private void Start()
    {
        playerStat = FindAnyObjectByType<PlayerStat>();
        playerAttack = FindAnyObjectByType<PlayerAttack>();
        timestamp = FindAnyObjectByType<Timestamp>();
        enemyManager = FindAnyObjectByType<EnemyManager>();
        pauseMenu.SetActive(false);
        gameOverPanel.SetActive(false);
        fuzzyLogic = FindAnyObjectByType<FuzzyLogic>();
        Time.timeScale = 1f;

        AudioManager.instance.PlayMusic("gameplay");
    }

    private void Update()
    {
        playerHealthUI.text = playerStat.currentHealth + "/100";
        playerHealthSlider.value = playerStat.currentHealth;
        coinUI.text = playerStat.coinValue + "/50";
        playerScoreUI.text = playerStat.playerScore.ToString();
        playerAnsweredUI.text = playerStat.playerAnswered + "/20";
        playerBantuanUI.text = playerStat.playerBantuan.ToString();
        enemyCount.text = enemyManager.enemyCount.ToString();
        if(playerAttack.bulletCount > 0)
        {
            bulletUI.text = playerAttack.bulletCount.ToString();
        }
        else
        {
            bulletUI.text = "-";
        }
        

        if(playerStat.isDead)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            AudioManager.instance.PlayMusic("gameover");
            playerStat.isDead = false;
        }

        if(playerStat.playerAnswered == 20)
        {
            keyUI.text = "1/1";
        }

        FinishStat();
        ChangeButtonText();
    }

    private void FinishStat()
    {
        sisaNyawa.text = playerStat.currentHealth.ToString();
        koinDikumpulkan.text = playerStat.coinValue.ToString();
        skorQuiz.text = playerStat.playerScore.ToString();
        waktuAkhir.text = timestamp.minute + " : " + timestamp.second;
    }

    public void PauseMenu()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MenuButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void BackPlay()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void NextOrRetryButtonLevel1()
    {
        Time.timeScale = 1f;
        if (fuzzyLogic.hasilAkhir >= 5)
        {
            SceneManager.LoadScene("Level2");
        }
        else
        {
            SceneManager.LoadScene("level1");
        }
    }

    public void NextOrRetryButtonLevel2()
    {
        Time.timeScale = 1f;
        if (fuzzyLogic.hasilAkhir >= 5)
        {
            SceneManager.LoadScene("Level3");
        }
        else
        {
            SceneManager.LoadScene("level2");
        }
    }

    public void NextOrRetryButtonLevel3()
    {
        Time.timeScale = 1f;
        if (fuzzyLogic.hasilAkhir >= 5)
        {
            SceneManager.LoadScene("Level4");
        }
        else
        {
            SceneManager.LoadScene("level3");
        }
    }

    public void NextOrRetryButtonLevel4()
    {
        Time.timeScale = 1f;
        if (fuzzyLogic.hasilAkhir >= 5)
        {
            SceneManager.LoadScene("Level5");
        }
        else
        {
            SceneManager.LoadScene("level4");
        }
    }

    public void RestartLevel1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void RestartLevel2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level2");
    }

    public void RestartLevel3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level3");
    }

    public void RestartLevel4()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level4");
    }

    public void RestartLevel5()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level5");
    }

    private void ChangeButtonText()
    {
        if (fuzzyLogic.hasilAkhir >= 5)
        {
            mainLagiButton.text = "Next Level";
        }
        else
        {
            mainLagiButton.text = "Main Lagi";
        }
    }
}
