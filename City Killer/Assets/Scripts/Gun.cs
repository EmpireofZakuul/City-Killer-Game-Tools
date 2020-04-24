using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    public float fireRate = 15f;
    public float hitForce = 60f;
    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1 / fireRate;
            Shoot();
        }
    }

    public void Shoot()
    {
        RaycastHit hit;
       if( Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
       {
            muzzleFlash.Play();
            Debug.Log(hit.transform.name);
            EnemyHealth health = hit.transform.GetComponent<EnemyHealth>();
            if(health != null)
            {
                health.damagetaken(damage);
            }

            if(hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }

          GameObject gameObject =  Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(gameObject, 2f);
       }
    }
}
