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

    public Rigidbody projectile;
    public float speed = 20;




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
            Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
            instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
            nextFire = Time.time + timeBetweenShots;
        }
       
        
    }
}


