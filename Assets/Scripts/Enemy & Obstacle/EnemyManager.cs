using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour, IDataPersistence
{
    public int enemyCount;
    public int enemyAdded;

    public GameObject[] aditionalEnemy;

    public void LoadData(GameData data)
    {
        enemyAdded = data.enemyAdded;
    }

    public void SaveData(ref GameData data)
    {
        data.enemyAdded = enemyAdded;
    }

    private void Start() {
        if(enemyAdded > 0)
        {
            for(int i = 0; i < aditionalEnemy.Length; i++)
            {
                aditionalEnemy[i].SetActive(false);
            }

            for(int i = 0; i < enemyAdded; i++)
            {
                aditionalEnemy[i].SetActive(true);
            }
        }
        else
        {
            for(int i = 0; i < aditionalEnemy.Length; i++)
            {
                aditionalEnemy[i].SetActive(false);
            }

            for(int i = 0; i < 5; i++)
            {
                aditionalEnemy[i].SetActive(true);
            }
        }
    }

}
