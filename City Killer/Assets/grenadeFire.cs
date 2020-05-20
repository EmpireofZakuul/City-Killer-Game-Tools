using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeFire : MonoBehaviour
{

    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float fireRate = 15f;
    public float hitForce = 60f;
    private float nextTimeToFire = 0f;
    public GameObject grenade;
    public Rigidbody Grenade;
    public float speed = 20;
    public Transform Hand;
  
    // Start is called before the first frame update
    void Update()
    {



        if (Input.GetButton("Fire2") && Time.time >= nextTimeToFire)
        //if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot();
        }

    }
    public void Shoot()
    {
        
        // Rigidbody instantiatedProjectile = Instantiate(Grenade, transform.position, transform.rotation) as Rigidbody;
        // instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

        GameObject gren = Instantiate(grenade, Hand.position, Hand.rotation) as GameObject;
        gren.GetComponent<Rigidbody>().AddForce(Hand.forward * speed, ForceMode.Impulse);
    }
}
