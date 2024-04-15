using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour, IDataPersistence
{
    public GameObject bulletPrefab;
    public GameObject swordCollider;
    public Transform bulletLocation;
    public float bulletSpeed = 10f;
    public float bulletRange = 5f;

    public int bulletMax;
    public int bulletCount;
    public int bulletAdded;

    private PlayerMovement playerMovement;
    private Animator anim;

    public List<GameObject> bulletPrefabList;
    public int selectedChar = 0;

    public void LoadData(GameData data)
    {
        selectedChar = data.characterSelected;
        bulletAdded = data.bulletAdded;
    }

    public void SaveData(ref GameData data)
    {

    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        bulletPrefab = bulletPrefabList[selectedChar];
        anim = GetComponent<Animator>();
        
        swordCollider.SetActive(false);

        if(selectedChar == 0)
        {
            bulletMax = 25; 
        }
        else if(selectedChar == 1)
        {
            bulletMax = 50;
        }
        else
        {
            bulletMax = 100;
        }

        bulletCount = bulletMax + bulletAdded;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (bulletCount > 0)
            {
                anim.SetTrigger("fireball");
                if(selectedChar == 0)
                {
                    AudioManager.instance.PlaySFX("char1");
                }
                else if(selectedChar == 1)
                {
                    AudioManager.instance.PlaySFX("char2");
                }
                else
                {
                    AudioManager.instance.PlaySFX("char3");
                }
            }
            else
            {
                bulletCount = 0;
                anim.SetTrigger("sword");
                AudioManager.instance.PlaySFX("pedang");
            }

        }
    }

    public void ShootBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletLocation.position, Quaternion.identity);

        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletCount--;

        if (playerMovement.isFacingRight)
        {
            bulletRB.velocity = transform.right * bulletSpeed;
        }
        else
        {
            bulletRB.velocity = -transform.right * bulletSpeed;
        }


        Destroy(bullet, bulletRange / bulletSpeed);
    }

    public void EnableCollider()
    {
        swordCollider.SetActive(true);
    }

    public void DisableCollider()
    {
        swordCollider.SetActive(false);
    }
}
