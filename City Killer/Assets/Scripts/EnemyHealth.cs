using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 50f;
    public Image HealthBar;
    //public float Health;


    public void Start()
    {
        //Health = health;
    }
    public void damagetaken(float amount)
    {
        health -= amount;
        HealthBar.fillAmount = health / health;
        if (health <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Destroy(gameObject);

       
    }

   
}
