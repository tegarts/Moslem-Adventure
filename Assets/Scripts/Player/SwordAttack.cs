using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttack : MonoBehaviour, IDataPersistence
{
    public string target;
    public int damage;
    private PlayerStat _playerStat;
    private HealthEnemy _healthEnemy;

    private int _selectedChar;

    public void LoadData(GameData data)
    {
        _selectedChar = data.characterSelected;
    }

    public void SaveData(ref GameData data)
    {

    }

    private void Start()
    {
        _playerStat = FindAnyObjectByType<PlayerStat>();
        if(_selectedChar == 0)
        {
            damage = 1;
        }
        else if(_selectedChar == 1)
        {
            damage = 2;
        }
        else
        {
            damage = 3;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(target))
        {
            if (target == "Player")
            {
                _playerStat.DamagedHealth(damage);
            }
            else if (target == "Enemy")
            {
                _healthEnemy = collision.gameObject.GetComponentInChildren<HealthEnemy>();
                _healthEnemy.TakingDamage(damage);
            }
        }
    }
}
