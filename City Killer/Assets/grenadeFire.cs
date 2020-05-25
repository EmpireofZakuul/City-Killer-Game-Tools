using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public int Grenadeamound = 5;
    public Text grenades;


    public void Start()
    {
        
    }
    // Start is called before the first frame update
    void Update()
    {
        grenades.text = Grenadeamound.ToString();
        if (Grenadeamound > 0)
        {



            if (Input.GetButton("Fire2") && Time.time >= nextTimeToFire)
            //if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / fireRate;
                Shoot();
            }
        }

    }
    public void Shoot()
    {
        Grenadeamound--;
        
        // Rigidbody instantiatedProjectile = Instantiate(Grenade, transform.position, transform.rotation) as Rigidbody;
        // instantiatedProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, speed));

        GameObject gren = Instantiate(grenade, Hand.position, Hand.rotation) as GameObject;
        gren.GetComponent<Rigidbody>().AddForce(Hand.forward * speed, ForceMode.Impulse);
    }
}
