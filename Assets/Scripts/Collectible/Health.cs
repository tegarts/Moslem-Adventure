using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private bool _isCollected;
    private PlayerStat _stat;

    private void Start()
    {
        _stat = FindAnyObjectByType<PlayerStat>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!_isCollected)
            {
                _stat.currentHealth += 10;
                if(_stat.currentHealth > 100)
                {
                    _stat.currentHealth = 100;
                }
                _isCollected = true;
                AudioManager.instance.PlaySFX("health");
                Destroy(gameObject);
            }
        }
    }
}
