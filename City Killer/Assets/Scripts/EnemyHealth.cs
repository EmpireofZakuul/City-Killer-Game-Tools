using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public Animator Animator;
    public float startHealth = 1000f;
    public Image HealthBar;
    private float health;
    //public float Health;


    public void Start()
    {
        health = startHealth;
        Animator = GetComponent<Animator>();
    }
    public void damagetaken(float amount)
    {
        health -= amount;
        HealthBar.fillAmount = health / startHealth;
        if (health <= 0)
        {
            Die();
        }

    }

    public void Die()
    {

        
        Animator.SetTrigger("Dead");
        Destroy(gameObject, 5f);
    }

   
}
