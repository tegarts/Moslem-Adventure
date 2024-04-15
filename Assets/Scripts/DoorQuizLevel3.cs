using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorQuizLevel3 : MonoBehaviour
{
    private bool isInsideCol = false;
    public GameObject popupButton;
    public GameObject soalUI1,soalUI2, soalUI3, soalUI4, soalUI5, hasilAkhir;
    public GameObject pauseButton;
    private int skor, minusHealth, rightAnswer, wrongAnswer;
    private PlayerStat playerStat;
    public TMP_Text skorAkhir;
    public TMP_Text minusHealthAkhir;
    public TMP_Text wrongAnswerText, rightAnswerText;
    public bool isDone;

    [Space]
    public List<Image> imageLevel1 = new();
    public List<Sprite> spriteLevel1 = new();
    public List<bool> boolLevel1 = new();
    public List<Button> buttonLevel1 = new();
    public int correctAmoutLevel1 = 0;

    [Space]
    public List<Image> imageLevel2 = new();
    public List<Sprite> spriteLevel2 = new();
    public List<bool> boolLevel2 = new();
    public List<Button> buttonLevel2 = new();
    public int correctAmoutLevel2 = 0;

    [Space]
    public List<Image> imageLevel3 = new();
    public List<Sprite> spriteLevel3 = new();
    public List<bool> boolLevel3 = new();
    public List<Button> buttonLevel3 = new();
    public int correctAmoutLevel3 = 0;

    [Space]
    public List<Image> imageLevel4 = new();
    public List<Sprite> spriteLevel4 = new();
    public List<bool> boolLevel4 = new();
    public List<Button> buttonLevel4 = new();
    public int correctAmoutLevel4 = 0;

    [Space]
    public List<Image> imageLevel5 = new();
    public List<Sprite> spriteLevel5 = new();
    public List<bool> boolLevel5 = new();
    public List<Button> buttonLevel5 = new();
    public int correctAmoutLevel5 = 0;

    private void Start()
    {
        popupButton.SetActive(false);
        soalUI1.SetActive(false);
        soalUI2.SetActive(false);
        soalUI3.SetActive(false);
        soalUI4.SetActive(false);
        soalUI5.SetActive(false);
        hasilAkhir.SetActive(false);
        playerStat = FindAnyObjectByType<PlayerStat>();
    }

    private void Update()
    {
        skorAkhir.text = "Skor: " + skor;
        minusHealthAkhir.text = "Nyawa Berkurang: " + minusHealth;
        rightAnswerText.text = "Jawaban Benar:           " + rightAnswer;
        wrongAnswerText.text = "Jawaban Salah:             " + wrongAnswer;
        if (isInsideCol)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                soalUI1.SetActive(true);
                pauseButton.SetActive(false);
                isInsideCol = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
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

    #region Soal 1

    public void Level1Button1()
    {
        if (!boolLevel1[0])
        {
            imageLevel1[0].sprite = spriteLevel1[0];
            boolLevel1[0] = true;
            buttonLevel1[0].interactable = false;
        }
        else if (boolLevel1[0] && !boolLevel1[1])
        {
            imageLevel1[1].sprite = spriteLevel1[0];
            boolLevel1[1] = true;
            correctAmoutLevel1 += 1;
            buttonLevel1[0].interactable = false;
        }
        else if (boolLevel1[1] && !boolLevel1[2])
        {
            imageLevel1[2].sprite = spriteLevel1[0];
            boolLevel1[2] = true;
            buttonLevel1[0].interactable = false;
            soalUI1.SetActive(false);
            soalUI2.SetActive(true);
        }
    }

    public void Level1Button2()
    {
        if (!boolLevel1[0])
        {
            imageLevel1[0].sprite = spriteLevel1[1];
            boolLevel1[0] = true;
            correctAmoutLevel1 += 1;
            buttonLevel1[1].interactable = false;

        }
        else if (boolLevel1[0] && !boolLevel1[1])
        {
            imageLevel1[1].sprite = spriteLevel1[1];
            boolLevel1[1] = true;
            buttonLevel1[1].interactable = false;
        }
        else if (boolLevel1[1] && !boolLevel1[2])
        {
            imageLevel1[2].sprite = spriteLevel1[1];
            boolLevel1[2] = true;
            buttonLevel1[1].interactable = false;
            soalUI1.SetActive(false);
            soalUI2.SetActive(true);
        }
    }

    public void Level1Button3()
    {
        if (!boolLevel1[0])
        {
            imageLevel1[0].sprite = spriteLevel1[2];
            boolLevel1[0] = true;
            buttonLevel1[2].interactable = false;
        }
        else if (boolLevel1[0] && !boolLevel1[1])
        {
            imageLevel1[1].sprite = spriteLevel1[2];
            boolLevel1[1] = true;
            buttonLevel1[2].interactable = false;
        }
        else if (boolLevel1[1] && !boolLevel1[2])
        {
            imageLevel1[2].sprite = spriteLevel1[2];
            boolLevel1[2] = true;
            correctAmoutLevel1 += 1;
            buttonLevel1[2].interactable = false;
            soalUI1.SetActive(false);
            soalUI2.SetActive(true);
        }
    }

    #endregion

    #region Soal 2

    public void Level2Button1()
    {
        if (!boolLevel2[0])
        {
            imageLevel2[0].sprite = spriteLevel2[0];
            boolLevel2[0] = true;
            buttonLevel2[0].interactable = false;
        }
        else if (boolLevel2[0] && !boolLevel2[1])
        {
            imageLevel2[1].sprite = spriteLevel2[0];
            boolLevel2[1] = true;
            correctAmoutLevel2 += 1;
            buttonLevel2[0].interactable = false;
        }
        else if (boolLevel2[1] && !boolLevel2[2])
        {
            imageLevel2[2].sprite = spriteLevel2[0];
            boolLevel2[2] = true;
            buttonLevel2[0].interactable = false;
            soalUI2.SetActive(false);
            soalUI3.SetActive(true);
        }
    }

    public void Level2Button2()
    {
        if (!boolLevel2[0])
        {
            imageLevel2[0].sprite = spriteLevel2[1];
            boolLevel2[0] = true;
            correctAmoutLevel2 += 1;
            buttonLevel2[1].interactable = false;

        }
        else if (boolLevel2[0] && !boolLevel2[1])
        {
            imageLevel2[1].sprite = spriteLevel2[1];
            boolLevel2[1] = true;
            buttonLevel2[1].interactable = false;
        }
        else if (boolLevel2[1] && !boolLevel2[2])
        {
            imageLevel2[2].sprite = spriteLevel2[1];
            boolLevel2[2] = true;
            buttonLevel2[1].interactable = false;
            soalUI2.SetActive(false);
            soalUI3.SetActive(true);
        }
    }

    public void Level2Button3()
    {
        if (!boolLevel2[0])
        {
            imageLevel2[0].sprite = spriteLevel2[2];
            boolLevel2[0] = true;
            buttonLevel2[2].interactable = false;
        }
        else if (boolLevel2[0] && !boolLevel2[1])
        {
            imageLevel2[1].sprite = spriteLevel2[2];
            boolLevel2[1] = true;
            buttonLevel2[2].interactable = false;
        }
        else if (boolLevel2[1] && !boolLevel2[2])
        {
            imageLevel2[2].sprite = spriteLevel2[2];
            boolLevel2[2] = true;
            correctAmoutLevel2 += 1;
            buttonLevel2[2].interactable = false;
            soalUI2.SetActive(false);
            soalUI3.SetActive(true);
        }
    }

    #endregion

    #region Soal 3

    public void Level3Button1()
    {
        if (!boolLevel3[0])
        {
            imageLevel3[0].sprite = spriteLevel3[0];
            boolLevel3[0] = true;
            buttonLevel3[0].interactable = false;
        }
        else if (boolLevel3[0] && !boolLevel3[1])
        {
            imageLevel3[1].sprite = spriteLevel3[0];
            boolLevel3[1] = true;
            correctAmoutLevel3 += 1;
            buttonLevel3[0].interactable = false;
        }
        else if (boolLevel3[1] && !boolLevel3[2])
        {
            imageLevel3[2].sprite = spriteLevel3[0];
            boolLevel3[2] = true;
            buttonLevel3[0].interactable = false;
        }
        else if (boolLevel3[2] && !boolLevel3[3])
        {
            imageLevel3[3].sprite = spriteLevel3[0];
            boolLevel3[3] = true;
            buttonLevel3[0].interactable = false;
            soalUI3.SetActive(false);
            soalUI4.SetActive(true);
        }
    }

    public void Level3Button2()
    {
        if (!boolLevel3[0])
        {
            imageLevel3[0].sprite = spriteLevel3[1];
            boolLevel3[0] = true;
            correctAmoutLevel3 += 1;
            buttonLevel3[1].interactable = false;
        }
        else if (boolLevel3[0] && !boolLevel3[1])
        {
            imageLevel3[1].sprite = spriteLevel3[1];
            boolLevel3[1] = true;
            buttonLevel3[1].interactable = false;
        }
        else if (boolLevel3[1] && !boolLevel3[2])
        {
            imageLevel3[2].sprite = spriteLevel3[1];
            boolLevel3[2] = true;
            buttonLevel3[1].interactable = false;
        }
        else if (boolLevel3[2] && !boolLevel3[3])
        {
            imageLevel3[3].sprite = spriteLevel3[1];
            boolLevel3[3] = true;
            buttonLevel3[1].interactable = false;
            soalUI3.SetActive(false);
            soalUI4.SetActive(true);
        }
    }

    public void Level3Button3()
    {
        if (!boolLevel3[0])
        {
            imageLevel3[0].sprite = spriteLevel3[2];
            boolLevel3[0] = true;
            buttonLevel3[2].interactable = false;
        }
        else if (boolLevel3[0] && !boolLevel3[1])
        {
            imageLevel3[1].sprite = spriteLevel3[2];
            boolLevel3[1] = true;
            buttonLevel3[2].interactable = false;
        }
        else if (boolLevel3[1] && !boolLevel3[2])
        {
            imageLevel3[2].sprite = spriteLevel3[2];
            boolLevel3[2] = true;
            correctAmoutLevel3 += 1;
            buttonLevel3[2].interactable = false;
        }
        else if (boolLevel3[2] && !boolLevel3[3])
        {
            imageLevel3[3].sprite = spriteLevel3[2];
            boolLevel3[3] = true;
            buttonLevel3[2].interactable = false;
            soalUI3.SetActive(false);
            soalUI4.SetActive(true);
        }
    }

    public void Level3Button4()
    {
        if (!boolLevel3[0])
        {
            imageLevel3[0].sprite = spriteLevel3[3];
            boolLevel3[0] = true;
            buttonLevel3[3].interactable = false;
        }
        else if (boolLevel3[0] && !boolLevel3[1])
        {
            imageLevel3[1].sprite = spriteLevel3[3];
            boolLevel3[1] = true;
            buttonLevel3[3].interactable = false;
        }
        else if (boolLevel3[1] && !boolLevel3[2])
        {
            imageLevel3[2].sprite = spriteLevel3[3];
            boolLevel3[2] = true;
            correctAmoutLevel3 += 1;
            buttonLevel3[3].interactable = false;
        }
        else if (boolLevel3[2] && !boolLevel3[3])
        {
            imageLevel3[3].sprite = spriteLevel3[3];
            boolLevel3[3] = true;
            buttonLevel3[3].interactable = false;
            soalUI3.SetActive(false);
            soalUI4.SetActive(true);
        }
    }

    #endregion

    #region Soal 4

    public void Level4Button1()
    {
        if (!boolLevel4[0])
        {
            imageLevel4[0].sprite = spriteLevel4[0];
            boolLevel4[0] = true;
            buttonLevel4[0].interactable = false;
        }
        else if (boolLevel4[0] && !boolLevel4[1])
        {
            imageLevel4[1].sprite = spriteLevel4[0];
            boolLevel4[1] = true;
            correctAmoutLevel4 += 1;
            buttonLevel4[0].interactable = false;
        }
        else if (boolLevel4[1] && !boolLevel4[2])
        {
            imageLevel4[2].sprite = spriteLevel4[0];
            boolLevel4[2] = true;
            buttonLevel4[0].interactable = false;
        }
        else if (boolLevel4[2] && !boolLevel4[3])
        {
            imageLevel4[3].sprite = spriteLevel4[0];
            boolLevel4[3] = true;
            buttonLevel4[0].interactable = false;
            soalUI4.SetActive(false);
            soalUI5.SetActive(true);
        }
    }

    public void Level4Button2()
    {
        if (!boolLevel4[0])
        {
            imageLevel4[0].sprite = spriteLevel4[1];
            boolLevel4[0] = true;
            correctAmoutLevel4 += 1;
            buttonLevel4[1].interactable = false;
        }
        else if (boolLevel4[0] && !boolLevel4[1])
        {
            imageLevel4[1].sprite = spriteLevel4[1];
            boolLevel4[1] = true;
            buttonLevel4[1].interactable = false;
        }
        else if (boolLevel4[1] && !boolLevel4[2])
        {
            imageLevel4[2].sprite = spriteLevel4[1];
            boolLevel4[2] = true;
            buttonLevel4[1].interactable = false;
        }
        else if (boolLevel4[2] && !boolLevel4[3])
        {
            imageLevel4[3].sprite = spriteLevel4[1];
            boolLevel4[3] = true;
            buttonLevel4[1].interactable = false;
            soalUI4.SetActive(false);
            soalUI5.SetActive(true);
        }
    }

    public void Level4Button3()
    {
        if (!boolLevel4[0])
        {
            imageLevel4[0].sprite = spriteLevel4[2];
            boolLevel4[0] = true;
            buttonLevel4[2].interactable = false;
        }
        else if (boolLevel4[0] && !boolLevel4[1])
        {
            imageLevel4[1].sprite = spriteLevel4[2];
            boolLevel4[1] = true;
            buttonLevel4[2].interactable = false;
        }
        else if (boolLevel4[1] && !boolLevel4[2])
        {
            imageLevel4[2].sprite = spriteLevel4[2];
            boolLevel4[2] = true;
            correctAmoutLevel4 += 1;
            buttonLevel4[2].interactable = false;
        }
        else if (boolLevel4[2] && !boolLevel4[3])
        {
            imageLevel4[3].sprite = spriteLevel4[2];
            boolLevel4[3] = true;
            buttonLevel4[2].interactable = false;
            soalUI4.SetActive(false);
            soalUI5.SetActive(true);
        }
    }

    public void Level4Button4()
    {
        if (!boolLevel4[0])
        {
            imageLevel4[0].sprite = spriteLevel4[3];
            boolLevel4[0] = true;
            buttonLevel4[3].interactable = false;
        }
        else if (boolLevel4[0] && !boolLevel4[1])
        {
            imageLevel4[1].sprite = spriteLevel4[3];
            boolLevel4[1] = true;
            buttonLevel4[3].interactable = false;
        }
        else if (boolLevel4[1] && !boolLevel4[2])
        {
            imageLevel4[2].sprite = spriteLevel4[3];
            boolLevel4[2] = true;
            correctAmoutLevel4 += 1;
            buttonLevel4[3].interactable = false;
        }
        else if (boolLevel4[2] && !boolLevel4[3])
        {
            imageLevel4[3].sprite = spriteLevel4[3];
            boolLevel4[3] = true;
            buttonLevel4[3].interactable = false;
            soalUI4.SetActive(false);
            soalUI5.SetActive(true);
        }
    }

    #endregion

    #region Soal 5

    public void Level5Button1()
    {
        if (!boolLevel5[0])
        {
            imageLevel5[0].sprite = spriteLevel5[0];
            boolLevel5[0] = true;
            buttonLevel5[0].interactable = false;
        }
        else if (boolLevel5[0] && !boolLevel5[1])
        {
            imageLevel5[1].sprite = spriteLevel5[0];
            boolLevel5[1] = true;
            correctAmoutLevel5 += 1;
            buttonLevel5[0].interactable = false;
        }
        else if (boolLevel5[1] && !boolLevel5[2])
        {
            imageLevel5[2].sprite = spriteLevel5[0];
            boolLevel5[2] = true;
            buttonLevel5[0].interactable = false;
        }
        else if (boolLevel5[2] && !boolLevel5[3])
        {
            imageLevel5[3].sprite = spriteLevel5[0];
            boolLevel5[3] = true;
            buttonLevel5[0].interactable = false;
            soalUI5.SetActive(false);
            hasilAkhir.SetActive(true);
        }
    }

    public void Level5Button2()
    {
        if (!boolLevel5[0])
        {
            imageLevel5[0].sprite = spriteLevel5[1];
            boolLevel5[0] = true;
            correctAmoutLevel5 += 1;
            buttonLevel5[1].interactable = false;
        }
        else if (boolLevel5[0] && !boolLevel5[1])
        {
            imageLevel5[1].sprite = spriteLevel5[1];
            boolLevel5[1] = true;
            buttonLevel5[1].interactable = false;
        }
        else if (boolLevel5[1] && !boolLevel5[2])
        {
            imageLevel5[2].sprite = spriteLevel5[1];
            boolLevel5[2] = true;
            buttonLevel5[1].interactable = false;
        }
        else if (boolLevel5[2] && !boolLevel5[3])
        {
            imageLevel5[3].sprite = spriteLevel5[1];
            boolLevel5[3] = true;
            buttonLevel5[1].interactable = false;
            soalUI5.SetActive(false);
            hasilAkhir.SetActive(true);
        }
    }

    public void Level5Button3()
    {
        if (!boolLevel5[0])
        {
            imageLevel5[0].sprite = spriteLevel5[2];
            boolLevel5[0] = true;
            buttonLevel5[2].interactable = false;
        }
        else if (boolLevel5[0] && !boolLevel5[1])
        {
            imageLevel5[1].sprite = spriteLevel5[2];
            boolLevel5[1] = true;
            buttonLevel5[2].interactable = false;
        }
        else if (boolLevel5[1] && !boolLevel5[2])
        {
            imageLevel5[2].sprite = spriteLevel5[2];
            boolLevel5[2] = true;
            correctAmoutLevel5 += 1;
            buttonLevel5[2].interactable = false;
        }
        else if (boolLevel5[2] && !boolLevel5[3])
        {
            imageLevel5[3].sprite = spriteLevel5[2];
            boolLevel5[3] = true;
            buttonLevel5[2].interactable = false;
            soalUI5.SetActive(false);
            hasilAkhir.SetActive(true);
        }
    }

    public void Level5Button4()
    {
        if (!boolLevel5[0])
        {
            imageLevel5[0].sprite = spriteLevel5[3];
            boolLevel5[0] = true;
            buttonLevel5[3].interactable = false;
        }
        else if (boolLevel5[0] && !boolLevel5[1])
        {
            imageLevel5[1].sprite = spriteLevel5[3];
            boolLevel5[1] = true;
            buttonLevel5[3].interactable = false;
        }
        else if (boolLevel5[1] && !boolLevel5[2])
        {
            imageLevel5[2].sprite = spriteLevel5[3];
            boolLevel5[2] = true;
            correctAmoutLevel5 += 1;
            buttonLevel5[3].interactable = false;
        }
        else if (boolLevel5[2] && !boolLevel5[3])
        {
            imageLevel5[3].sprite = spriteLevel5[3];
            boolLevel5[3] = true;
            buttonLevel5[3].interactable = false;
            soalUI5.SetActive(false);
            hasilAkhir.SetActive(true);
        }
    }

    #endregion

    #region Hasil

    public void TombolBack()
    {
        hasilAkhir.SetActive(false);
        pauseButton.SetActive(true);
        isDone = true;
    }

    #endregion
}
