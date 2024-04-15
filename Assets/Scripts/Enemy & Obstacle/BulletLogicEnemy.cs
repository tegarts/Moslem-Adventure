using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLogicEnemy : MonoBehaviour
{
    public int damage;
    private PlayerStat _playerStat;

    private void Start()
    {
        _playerStat = FindAnyObjectByType<PlayerStat>();
    }

    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerStat.DamagedHealth(damage);
            Destroy(gameObject);
        }
    }
}
