using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    public int damage;
    private HealthEnemy _healthEnemy;
    private PlayerMovement _movement;

    private void Start()
    {
        _movement = FindAnyObjectByType<PlayerMovement>();
    }

    private void Update()
    {
        if (_movement.isFacingRight)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            _healthEnemy = collision.gameObject.GetComponentInChildren<HealthEnemy>();
            _healthEnemy.TakingDamage(damage);
            Destroy(gameObject);
        }
    }
}
