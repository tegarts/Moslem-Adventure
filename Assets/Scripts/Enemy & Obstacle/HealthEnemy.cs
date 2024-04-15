using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private int damage;

    [Header("Enemy Health")]
    public int enemyHealth;
    //private SpriteRenderer spriteRend;
    //[SerializeField] private float iFramesDuration;
    //[SerializeField] private int numberOfFlashes;
    [SerializeField] private GameObject parent;

    public Animator anim;

    private void Start()
    {
        //spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakingDamage(int _damage)
    {
        enemyHealth -= _damage;

        if (enemyHealth > 0)
        {
            //StartCoroutine(TakingDamage());
            anim.SetTrigger("hurt");
        }
        else if (enemyHealth <= 0)
        {
            enemyHealth = 0;
            StartCoroutine(Dying());
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerStat>().DamagedHealth(damage);
        }
    }

    //IEnumerator TakingDamage()
    //{
    //    for (int i = 0; i < numberOfFlashes; i++)
    //    {
    //        spriteRend.color = new Color(0.2f, 0.2f, 0.2f, 0.5f);
    //        yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
    //        spriteRend.color = Color.white;
    //        yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
    //    }
    //}

    IEnumerator Dying()
    {
        anim.SetTrigger("dead");
        yield return new WaitForSeconds(0.5f);
        Destroy(parent);
    }
}
