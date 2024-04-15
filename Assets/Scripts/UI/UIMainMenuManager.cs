using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenuManager : MonoBehaviour, IDataPersistence
{
    private int levelOpen = 0;
    // MAIN MENU
    public GameObject panelExit;
    public GameObject panelSetting;
    public GameObject panelStart;
    public GameObject panelPetunjuk;
    public GameObject panelControl;
    public GameObject panelToko;

    // Button Level
    public Button[] buttonLevel = new Button[5];
    public GameObject[] imageLock = new GameObject[4];

    [Header("Start")]
    public GameObject panelPowerup;
    public List<GameObject> listPowerup;
    public TMP_Text bulletBonus;
    public TMP_Text healthBonus;
    public int HealthAdded, BulletAdded;

    [Header("Toko")]
    public List<Button> buttons = new();
    public static int selectedChar = 0;
    public List<Animator> anim = new();
    private bool char2, char3;
    public GameObject buyChar2, buyChar3;
    public GameObject coinNotEnough2, coinNotEnough3;
    public TMP_Text coinText;
    [SerializeField] private int coin;
    public GameObject panelInfoChar;
    public TMP_Text charName;
    public List<string> charString;
    public TMP_Text healthText;
    public List<string> healthString;
    public TMP_Text peluruText;
    public List<string> peluruString;
    public TMP_Text damageWeaponText;
    public List<string> damageWeaponString;
    public TMP_Text damageFistText;
    public List<string> damageFistString;
    public List<GameObject> imageChar;
    public TMP_Text char2name, char3name;

    public void LoadData(GameData data)
    {
        selectedChar = data.characterSelected;
        char2 = data.char2;
        char3 = data.char3;
        coin = data.coin;
        levelOpen = data.levelUnlocked;

        HealthAdded = data.healthAdded;
        BulletAdded = data.bulletAdded;

    }

    public void SaveData(ref GameData data)
    {
        data.characterSelected = selectedChar;
        data.char2 = char2;
        data.char3 = char3;
        data.coin = coin;
    }

    private void Start()
    {
        panelExit.SetActive(false);
        panelSetting.SetActive(false);
        panelStart.SetActive(false);
        panelPetunjuk.SetActive(false);
        panelControl.SetActive(false);
        panelToko.SetActive(false);
        buyChar2.SetActive(false);
        buyChar3.SetActive(false);
        coinNotEnough2.SetActive(false);
        coinNotEnough3.SetActive(false);
        panelPowerup.SetActive(false);

        for(int i = 0; i < listPowerup.Count; i++)
        {
            listPowerup[i].SetActive(false);
        }

        AudioManager.instance.PlayMusic("menu");

        for (int i = 0; i < buttonLevel.Length; i++)
        {
            buttonLevel[i].interactable = false;
        }

        for(int i = 0; i < imageLock.Length; i++)
        {
            imageLock[i].SetActive(true);
        }

        if (!DataPersistenceManager.instance.HasGameData())
        {
            DataPersistenceManager.instance.NewGame();
            Debug.Log("New Game");
        }
        else
        {
            Debug.Log("Load Game");
        }
    }

    private void Update()
    {
        coinText.text = coin.ToString();
        buttons[selectedChar].interactable = false;
        if(panelToko.activeSelf)
        {
            anim[selectedChar].SetBool("idle", true);
        }
        
        if(levelOpen == 0)
        {
            buttonLevel[0].interactable = true;
        }
        else if(levelOpen == 1)
        {
            buttonLevel[0].interactable = true;
            buttonLevel[1].interactable = true;
            imageLock[0].SetActive(false);
        }
        else if(levelOpen == 2)
        {
            buttonLevel[0].interactable = true;
            buttonLevel[1].interactable = true;
            buttonLevel[2].interactable = true;
            imageLock[0].SetActive(false);
            imageLock[1].SetActive(false);
        }
        else if (levelOpen == 3)
        {
            buttonLevel[0].interactable = true;
            buttonLevel[1].interactable = true;
            buttonLevel[2].interactable = true;
            buttonLevel[3].interactable = true;
            imageLock[0].SetActive(false);
            imageLock[1].SetActive(false);
            imageLock[2].SetActive(false);
        }
        else if (levelOpen == 4)
        {
            buttonLevel[0].interactable = true;
            buttonLevel[1].interactable = true;
            buttonLevel[2].interactable = true;
            buttonLevel[3].interactable = true;
            buttonLevel[4].interactable = true;
            imageLock[0].SetActive(false);
            imageLock[1].SetActive(false);
            imageLock[2].SetActive(false);
            imageLock[3].SetActive(false);
        }

        CheckCharacterLocked();
        CalculateBonus();
    }

    #region MainMenu


    public void OpenExit()
    {
        panelExit.SetActive(true);
    }

    public void OpenSetting()
    {
        panelSetting.SetActive(true);
    }

    public void OpenStart()
    {
        panelStart.SetActive(true);
    }

    public void OpenPetunjuk()
    {
        panelPetunjuk.SetActive(true);
    }

    public void OpenKontrol()
    {
        panelControl.SetActive(true);
    }

    public void OpenToko()
    {
        panelToko.SetActive(true);
    }

    #endregion

    #region Exit

    public void CloseExit()
    {
        panelExit.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    #endregion

    #region Setting

    public void CloseSetting()
    {
        panelSetting.SetActive(false);
    }

    #endregion

    #region Start

    public void CloseStart()
    {
        panelStart.SetActive(false);
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void StartLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void StartLevel5()
    {
        SceneManager.LoadScene("Level5");
    }

    public void OpenPowerUp()
    {
        panelPowerup.SetActive(true);
    }

    public void ClosePowerUp()
    {
        panelPowerup.SetActive(false);
    }

    private void CalculateBonus()
    {
        if(HealthAdded > 0)
        {
            listPowerup[0].SetActive(true);
            healthBonus.text = "+" + HealthAdded;
        }

        if(BulletAdded > 0)
        {
            listPowerup[1].SetActive(true);
            bulletBonus.text = "+" + BulletAdded;
        }

        if(HealthAdded == 0 && BulletAdded == 0)
        {
            listPowerup[2].SetActive(true);
        }
    }

    #endregion

    #region Petunjuk

    public void ClosePetunjuk()
    {
        panelPetunjuk.SetActive(false);
    }

    #endregion

    #region Kontrol

    public void CloseKontrol()
    {
        panelControl.SetActive(false);
    }

    #endregion

    #region Toko

    public void CloseToko()
    {
        panelToko.SetActive(false);
    }

    public void SelectChar1()
    {
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].interactable = true;
            anim[i].SetBool("idle", false);
        }
        selectedChar = 0;
    }

    public void SelectChar2()
    {
        if(char2)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].interactable = true;
                anim[i].SetBool("idle", false);
            }
            selectedChar = 1;
        }
        else
        {
            buyChar2.SetActive(true);
        }
        
    }

    public void BoughtChar2()
    {
        if(coin >= 200)
        {
            char2 = true;
            coin -= 200;
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].interactable = true;
                anim[i].SetBool("idle", false);
            }
            selectedChar = 1;
            buyChar2.SetActive(false);
        }
        else
        {
            coinNotEnough2.SetActive(true);
        }
    }

    public void notBuyChar2()
    {
        buyChar2.SetActive(false);
        coinNotEnough2.SetActive(false);
    }

    public void SelectChar3()
    {
        if (char3)
        {
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].interactable = true;
                anim[i].SetBool("idle", false);
            }
            selectedChar = 2;
        }
        else
        {
            buyChar3.SetActive(true);
        }
    }

    public void BoughtChar3()
    {
        if (coin >= 400)
        {
            char3 = true;
            coin -= 400;
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].interactable = true;
                anim[i].SetBool("idle", false);
            }
            selectedChar = 2;
            buyChar3.SetActive(false);
        }
        else
        {
            coinNotEnough3.SetActive(true);
        }
    }

    public void notBuyChar3()
    {
        buyChar3.SetActive(false);
        coinNotEnough3.SetActive(false);
    }

    public void InfoChar1()
    {
        panelInfoChar.SetActive(true);
        imageChar[0].SetActive(true);
        imageChar[1].SetActive(false);
        imageChar[2].SetActive(false);
        charName.text = charString[0];
        healthText.text = healthString[0];
        peluruText.text = peluruString[0];
        damageWeaponText.text = damageWeaponString[0];
        damageFistText.text = damageFistString[0];
    }

    public void InfoChar2()
    {
        panelInfoChar.SetActive(true);
        imageChar[0].SetActive(false);
        imageChar[1].SetActive(true);
        imageChar[2].SetActive(false);
        charName.text = charString[1];
        healthText.text = healthString[1];
        peluruText.text = peluruString[1];
        damageWeaponText.text = damageWeaponString[1];
        damageFistText.text = damageFistString[1];
    }

    public void InfoChar3()
    {
        panelInfoChar.SetActive(true);
        imageChar[0].SetActive(false);
        imageChar[1].SetActive(false);
        imageChar[2].SetActive(true);
        charName.text = charString[2];
        healthText.text = healthString[2];
        peluruText.text = peluruString[2];
        damageWeaponText.text = damageWeaponString[2];
        damageFistText.text = damageFistString[2];
    }

    public void ExitInfoChar()
    {
        panelInfoChar.SetActive(false);
    }

    private void CheckCharacterLocked()
    {
        if(char2)
        {
            char2name.text = "Karakter Dimiliki";
        }
        else
        {
            char2name.text = "Buy 200 Coin";
        }

        if(char3)
        {
            char3name.text = "Karakter Dimiliki";
        }
        else
        {
            char3name.text = "Buy 400 Coin";
        }
    }


    #endregion
}
