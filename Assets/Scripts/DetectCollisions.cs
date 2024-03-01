using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private HealthBar healthBar;

    private void Start()
    {
        healthBar = transform.Find("HealthBar").GetComponent<HealthBar>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            healthBar.ChangeHealthAmount(-20);
            if (healthBar.actualHealth <= 0)
            {
                Destroy(gameObject);
            }
        }



    }
}
