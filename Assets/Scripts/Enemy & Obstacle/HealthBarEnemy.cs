using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarEnemy : MonoBehaviour
{
    [SerializeField] private Transform enemyTransform;
    public float distanceWithEnemy;

    public Slider healthBarSlider;

    [SerializeField] private HealthEnemy healthEnemy;

    private GameObject goParent;

    public TMP_Text healthNumber;
    private int maxHealth;

    private void Start()
    {
        enemyTransform = transform.parent;
        healthBarSlider = GetComponentInChildren<Slider>();
        goParent = transform.parent.gameObject;
        healthEnemy = goParent.GetComponentInChildren<HealthEnemy>();

        healthBarSlider.maxValue = healthEnemy.enemyHealth;

        healthNumber = GetComponentInChildren<TMP_Text>();

        maxHealth = healthEnemy.enemyHealth;


    }

    private void Update()
    {
        Vector3 newPosition = enemyTransform.position + Vector3.up * distanceWithEnemy;

        transform.position = newPosition;

        transform.localScale = new Vector3(enemyTransform.localScale.x, transform.localScale.y, transform.localScale.z);

        healthBarSlider.value = healthEnemy.enemyHealth;

        healthNumber.text = healthEnemy.enemyHealth + "/" + maxHealth;

    }
}
