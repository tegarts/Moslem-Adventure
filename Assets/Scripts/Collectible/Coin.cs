using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool _isCollected;
    private PlayerStat _playerStat;

    private void Start()
    {
        _playerStat = FindAnyObjectByType<PlayerStat>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(!_isCollected)
            {
                _playerStat.coinValue++;
                _isCollected = true;
                AudioManager.instance.PlaySFX("coin");
                Destroy(gameObject);
            }
        }
    }
}
