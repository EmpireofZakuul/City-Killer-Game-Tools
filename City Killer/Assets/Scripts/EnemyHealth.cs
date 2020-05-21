using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{

    //public float maxHealth = 3f;
    //public static float health;
    public float health = 3f;
    public Image HealthBar;
    bool Death = true;
    public GameObject thisEnemy;
    public bool dead = true;
   




    void Start()
    {
        HealthBar = GetComponent<Image>();
        //health = maxHealth;
    
        
    }

    // Update is called once per frame
    void Update()
    {


        if (health == 0 && dead == true)
        {
            Die();

            //HealthBar.fillAmount = health / maxHealth;
            //if (health <= 0)
            // {
            // Die();
            // Death = false;

            // }

        }
    }
 
  // void Die()
    //{
        //if (health <= 0 && !Death)
       // {
           // Destroy(thisEnemy);
            //SceneManager.LoadScene("Win");
          //  Death = true;
        //}


   // }

    public void TakeDamage2(int damage)
    {
        health -= damage;
        dead = true;
       

        Debug.Log("damage Taken");
    }

    void Die()
    {
        //waveSpawner.Enemiesalive--;
        three_point_wavespawner.Enemiesalive--;
        Destroy(gameObject);
        dead = false;
       
    }


}
