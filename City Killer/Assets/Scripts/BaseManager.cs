using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BaseManager : MonoBehaviour
{
    public Text Base;
    public float baseHealth = 10;
    private  float health;
    public bool Lost = false;
    public void Start()
    {
        //baseHealth = 10;
        //Base = gameObject.GetComponent<Text>();
        Base.text = baseHealth.ToString();
        health = baseHealth;
    }
    public void Update()
    {
        if(baseHealth <= 0 && !Lost)
        {
            
            SceneManager.LoadScene("Lose");
            Lost = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {

            baseHealth--;
            
        }
    }

    // #region Singleton

    //public static BaseManager instance;

    // void Awake()
    //{
    //  instance = this;
    // }
    //#endregion

    //public GameObject Base;
}
