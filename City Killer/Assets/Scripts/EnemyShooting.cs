using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooting : MonoBehaviour
{

    public GameObject player;
    public GameObject bulletPrefab;
    public float timeBetweenShots;
    public float nextFire;
    public GameObject firePoint;
  




    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShots = 0.25f;
        nextFire = Time.time;

    }

    // Update is called once per frame
    void Update()
    {

       Shooting();
    }

    public void Shooting()
    {
      
       
        if(Time.time < nextFire)
        {
           firePoint =  Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            nextFire = Time.time + timeBetweenShots;
        }
       
        
    }
}


