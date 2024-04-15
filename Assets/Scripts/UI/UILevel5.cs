using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevel5 : MonoBehaviour
{
    public List<Button> listButton;
    private FuzzyLogic fuzzyLogic;
    public GameObject panelTamat;

    private void Start()
    {
        fuzzyLogic = FindAnyObjectByType<FuzzyLogic>();

        for(int i = 0; i < listButton.Count; i++)
        {
            listButton[i].gameObject.SetActive(false);
        }

        panelTamat.SetActive(false);
    }

    private void Update()
    {
        if (fuzzyLogic.hasilAkhir >= 5)
        {
            listButton[0].gameObject.SetActive(true);
            listButton[1].gameObject.SetActive(false);
            listButton[2].gameObject.SetActive(false);
        }
        else
        {
            listButton[0].gameObject.SetActive(false);
            listButton[1].gameObject.SetActive(true);
            listButton[2].gameObject.SetActive(true);
        }
    }

    public void OpenPanelTamat()
    {
        panelTamat.SetActive(true);
    }


}
