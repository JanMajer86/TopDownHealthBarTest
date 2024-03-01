using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 100f;
    private float actualHealth;

    // Start is called before the first frame update
    void Start()
    {
        actualHealth = healthAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            Heal(20);
        }
    }

    public void TakeDamage(float damage)
    {

        actualHealth -= damage;
        healthBar.fillAmount = actualHealth / healthAmount;
    }

    public void Heal(float healingAmount)
    {
        actualHealth += healingAmount;
        actualHealth = Mathf.Clamp(actualHealth, 0, healthAmount);

        healthBar.fillAmount = actualHealth / healthAmount;
    }

}
