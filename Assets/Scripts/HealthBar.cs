using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthBar;
    public float maxHealth = 60;
    public float actualHealth;
    void Start()
    {
        actualHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeHealthAmount(-20);
        }
        if (Input.GetMouseButtonDown(1))
        {
            ChangeHealthAmount(10);
        }
    }

    public void ChangeHealthAmount(float amount)
    {
        actualHealth += amount;
        healthBar.fillAmount = actualHealth / maxHealth;

    }
}
