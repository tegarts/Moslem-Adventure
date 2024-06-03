using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGateLogic : MonoBehaviour
{
    private PlayerStat playerStat;
    private bool openGate;
    public GameObject popUp;
    public GameObject popupNotyet;
    private bool isInside;
    private bool isDone;
    [Header("Gate Transition")]
    public float endY = 7f;
    public float duration = 1f;
    private float elapsedTime = 0f;

    private void Start()
    {
        playerStat = FindAnyObjectByType<PlayerStat>();
        popUp.SetActive(false);
        popupNotyet.SetActive(false);
        
    }

    private void Update()
    {
        if(playerStat.playerAnswered == 20)
        {
            openGate = true;
        }

        if(isDone)
        {
            GateTransition();
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (openGate && isInside)
            {
                isDone = true;
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

    private void GateTransition()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        float y = Mathf.Lerp(gameObject.transform.position.y, endY, t);
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        if(t >= 1f)
        {
            elapsedTime = 0f;
        }
    }
}
