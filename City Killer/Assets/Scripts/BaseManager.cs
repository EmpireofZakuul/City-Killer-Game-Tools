using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BaseManager : MonoBehaviour
{
    public Text Base;
    public int baseHealth = 10;
    public  int health;
    public bool Lost = false;
    public void Start()
    {
        //baseHealth = 10;
        //Base = gameObject.GetComponent<Text>();
        //Base.text = health.ToString();
        health = baseHealth;
    }
    public void Update()
    {
        Base.text = baseHealth.ToString() + " / " + health.ToString() ;
        if (baseHealth <= 0 && !Lost)
        {
            
            SceneManager.LoadScene("Lose");
            Lost = true;
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Enemy")
        {

            baseHealth-=1;
            
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
