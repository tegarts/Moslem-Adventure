using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStat : MonoBehaviour, IDataPersistence
{
    [Header("Health")]
    [SerializeField] private int initialHealth = 25;
    public int currentHealth;
    public int healthAdded;
    public bool isDead;
    private bool isDamaged;
    private SpriteRenderer sRenderer;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    public List<RuntimeAnimatorController> controller;
    private Animator anim;
    public int selectedChar = 0;

    [Header("Coin")]
    public int coinValue;

    public void LoadData(GameData data)
    {
        selectedChar = data.characterSelected;
        healthAdded = data.healthAdded;
    }

    public void SaveData(ref GameData data)
    {
        data.coin += coinValue;
    }

    private void Start()
    {
        if(selectedChar == 0)
        {
            initialHealth = 15;
        }
        else if(selectedChar == 1)
        {
            initialHealth = 20;
        }
        else
        {
            initialHealth = 25;
        }

        currentHealth = initialHealth + healthAdded;
        sRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        anim.runtimeAnimatorController = controller[selectedChar];
    }

    public void DamagedHealth(int damage)
    {
        if (!isDamaged)
        {
            currentHealth -= damage;
            isDamaged = true;
            
        }
        
        if(currentHealth > 0)
        {
            AudioManager.instance.PlaySFX("hurt");
            StartCoroutine(Invunerability());
        }
        else
        {
            if(!isDead)
            {
                anim.SetTrigger("dead");
                AudioManager.instance.PlaySFX("dead");
                isDead = true;
            }
        }
    }

    IEnumerator Invunerability()
    {
        anim.SetTrigger("hurt");
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            sRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            sRenderer.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        isDamaged = false;
    }

}
