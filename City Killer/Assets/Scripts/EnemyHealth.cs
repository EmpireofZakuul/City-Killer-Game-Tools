using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{

    //public float maxHealth = 3f;
    //public static float health;
    public float health = 3f;
    //public Image HealthBar;
    bool Death = true;
    public GameObject thisEnemy;
    public bool dead = true;
    public float Health = 3f;
    public GameObject rididbod;

    public NavMeshAgent navNpc;






    void Start()
    {
        // HealthBar = GetComponent<Image>();
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
        if (Health == 0 )
        {

        
            CarDie();

           

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

    public void TakeDamage3(int damage)
    {
        Health -= damage;
        dead = true;


        Debug.Log("damage car");
    }

    void Die()
    {
        //waveSpawner.Enemiesalive--;
        three_point_wavespawner.Enemiesalive--;
        Destroy(gameObject);
        dead = false;
       
    }

    void CarDie()
    {
        rididbod.GetComponentInChildren<Rigidbody>().useGravity = true;
        thisEnemy.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
        navNpc.isStopped = true;
        Destroy(gameObject, 3f);
            dead = false;
       


    }


}
