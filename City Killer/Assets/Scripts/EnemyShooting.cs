using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyShooting : MonoBehaviour
{
    public EnemyMovement EnemyMovement;
    public GameObject player;
    public GameObject bulletPrefab;
    public float timeBetweenShots;
    public float nextFire;
    public GameObject firePoint;

    public Rigidbody projectile;
    public float speed = 20;
    public Transform target;
    private float nextTimeToFire = 5f;
    public float fireRate = 2f;




    // Start is called before the first frame update
    void Start()
    {
        timeBetweenShots = 0.25f;
        nextFire = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= EnemyMovement.stopRadius && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shooting();
        }
       
    }

    public void Shooting()
    {


        Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
        instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));




        // if(Time.time < nextFire)
        // {
        //  Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation) as Rigidbody;
        // instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));
        //  nextFire = Time.time + timeBetweenShots;
        //}


    }
}


