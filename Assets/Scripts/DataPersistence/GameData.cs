using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int characterSelected;
    public bool char2, char3;
    public int coin;
    public float musicValue, sfxValue;
    public int levelUnlocked;
    public int healthAdded;
    public int bulletAdded;
    public int helpAdded;
    public int enemyAdded;
    public GameData()
    {
        this.characterSelected = 0;
        this.char2 = false;
        this.char3 = false;
        this.coin = 0;
        this.musicValue = 0;
        this.sfxValue = 0;
        this.levelUnlocked = 0;
        this.healthAdded = 0;
        this.bulletAdded = 0;
        this.helpAdded = 0;
        this.enemyAdded = 0;
    }
}
