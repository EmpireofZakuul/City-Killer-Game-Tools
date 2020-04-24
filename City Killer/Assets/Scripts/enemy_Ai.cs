using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy_Ai : MonoBehaviour
{
    [Header("Boss stats")]
    public GameObject powerup;
    public bool isaboss = false;
  
  
    private GameObject player;
    private GameObject Base;
    [Header("Stats")]
    public float health = 2;
    private float Health;
    public int dropmoney = 50;    
    public float startspeed =5f;
    public float range = 5f;
    [HideInInspector]
    public float Speed;
    public NavMeshAgent brain;
    public Image HeathBar;
    

    void Start()
    {
       
        Base = GameObject.FindGameObjectWithTag("Base");
        brain = GetComponent<NavMeshAgent>();      
      //  brain.destination = Base.transform.position;
        Speed = startspeed;
        Health = health;
    }


   
    public void Slow (float pct)
    {       
        Speed = startspeed * (1f - pct);
      
      
    }
     void Die()
    {
        Destroy(gameObject);
        waveSpawner.Enemiesalive--;
        
                
    }
    // Update is called once per frame
    void Update()
    {
       
        player = GameObject.FindGameObjectWithTag("Player");       
        brain.speed = Speed;
        Speed = startspeed;
        brain.destination = Base.transform.position;
        float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToEnemy < range)
        {
           brain.destination = player.transform.position;          
        }
        
       

    }

    void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "Base")
       {
          // stats.Health--;
           waveSpawner.Enemiesalive--;
           Destroy(gameObject);
      }
       if(other.tag == "Player")
        {
           // main_charcter.Health--;
            Debug.Log("hit");
        }
   }
}
