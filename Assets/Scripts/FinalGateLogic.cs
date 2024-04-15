using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGateLogic : MonoBehaviour
{
    private DoorQuiz doorQuiz;
    private bool openGate;
    private Animator anim;
    public GameObject popUp;
    public GameObject popupNotyet;
    private bool isInside;

    private void Start()
    {
        doorQuiz = FindAnyObjectByType<DoorQuiz>();
        anim = GetComponent<Animator>();
        popUp.SetActive(false);
        popupNotyet.SetActive(false);
    }

    private void Update()
    {
        if(doorQuiz.isDone)
        {
            openGate = true;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (openGate && isInside)
            {
                anim.SetBool("open", true);
            }
            else if (!openGate && isInside)
            {
                popupNotyet.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            popUp.SetActive(true);
            isInside = true;
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

    public void BackButton()
    {
        popupNotyet.SetActive(false);
    }
}
