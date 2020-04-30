using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public static float health;
    public Image HealthBar;
    bool Death = true;
    public GameObject thisEnemy;




    void Start()
    {
        HealthBar = GetComponent<Image>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {



        HealthBar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            Die();
            Death = false;
           
        }

    }
 
   void Die()
    {
        if (health <= 0 && !Death)
        {
            Destroy(thisEnemy);
            //SceneManager.LoadScene("Win");
            Death = true;
        }


    }


}
