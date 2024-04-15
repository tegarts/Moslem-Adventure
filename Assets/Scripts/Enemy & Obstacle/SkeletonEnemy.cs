using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SkeletonEnemy : MonoBehaviour
{
    public Transform leftEdge;
    public Transform rightEdge;
    private bool movingLeft;
    public float speed = 2;
    public int damageToPlayer;
    private Vector3 initScale;

    private bool playerInsideCollider = false;
    private PlayerStat playerStat;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        initScale = transform.localScale;
        playerStat = FindAnyObjectByType<PlayerStat>();
    }

    private void MoveInDirection(int _direction)
    {
        if (!playerInsideCollider)
        {
            transform.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
            transform.position = new Vector3(transform.position.x + Time.deltaTime * _direction * speed, transform.position.y, transform.position.z);
        }
        
    }

    private void DirectionChange()
    {
        movingLeft = !movingLeft;
    }

    private void Update()
    {
        if(!playerInsideCollider)
        {
            if (movingLeft)
            {
                if (transform.position.x >= leftEdge.position.x)
                {
                    MoveInDirection(-1);
                }
                else
                {
                    DirectionChange();
                }
            }
            else
            {
                if (transform.position.x <= rightEdge.position.x)
                {
                    MoveInDirection(1);
                }
                else
                {
                    DirectionChange();
                }
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerInsideCollider = true;
            anim.SetBool("attack", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerInsideCollider = false;
            anim.SetBool("attack", false);
        }
    }

    public void AttackPlayer()
    {
        playerStat.DamagedHealth(damageToPlayer);
    }
}
