using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{


    public float startHealth = 100f;
    private  float health;
    public Image HealthBar;
    bool Death = true;




    void Start()
    {
        HealthBar = GetComponent<Image>();
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {

        HealthBar.fillAmount = health/ startHealth;
        if (health < 0)
        {
            Die();
            Death = false;

        }

    }
    void Die()
    {
        if (health < 0 && !Death)
        {

            SceneManager.LoadScene("Lose");
            Death = true;
        }
    }
}
