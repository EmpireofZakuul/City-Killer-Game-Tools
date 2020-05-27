using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyExplode : MonoBehaviour
{
    public float lookRadius = 20f;
    public float stopRadius = 10f;
    public NavMeshAgent nav;
    Transform target;
    // public Transform playerCharacter;
    public float originalSpeed = 5;
    public static float maxSpeed;
    public float speed = 20;
    // Start is called before the first frame update
    private GameObject player;
    Transform basePlayer;//bases transform
    private GameObject Base;
    public Vector3 baseLocation;



    public float BlowRadius =6f;
    public float expolsiveForce = 20f;
    public float delay = 3f;
    private float countdown;
    bool hasexploded = false;
    public static int BulletDamage;
    public int damage = 1;

    public Transform explosionEffect;
    public AudioSource source;
    public AudioClip shot;

    public AudioSource sourceBeep;
    public AudioClip shotbeep;
    public bool Explodeenemy = false;
    public bool beeped = false;


    void Start()
    {
        Base = GameObject.FindGameObjectWithTag("Base");
        player = GameObject.FindGameObjectWithTag("Player");
        target = playerManager.instance.player.transform;
        // basePlayer = BaseManager.instance.Base.transform;// geting the bases singleton
        nav.GetComponent<NavMeshAgent>();
        originalSpeed = maxSpeed;
        three_point_wavespawner.Enemiesalive++;
        // nav.destination = basePlayer.position;
    }

    // Update is called once per frame
    void Update()
    {

       

        float distance = Vector3.Distance(target.position, transform.position);
       
            nav.SetDestination(target.position);

        if (distance <= lookRadius &&!beeped)
        {
            Beep();
        }

        if (distance <= stopRadius && !Explodeenemy)
        {
            //stopAgent();
            // Shooting();

            Explode();
        }

    }
/*
    public void stopAgent()
    {
        nav.isStopped = false;
        Vector3 unpausedSpeed = Vector3.zero;
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= stopRadius)
        {

            //nav.velocity = Vector3.zero;
            //nav.isStopped = true;
            gameObject.GetComponent<NavMeshAgent>().velocity = Vector3.zero;
        }
        else
        {
            if (distance >= stopRadius)
            {

                nav.isStopped = false;
                nav.velocity = unpausedSpeed;
                nav.SetDestination(target.position);
                nav.speed = originalSpeed;
            }
        }
    }

    */
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }

   // void OnTriggerEnter(Collider other)
    //{

       // if (other.tag == "Base")
       // {

            //waveSpawner.Enemiesalive--;
         
           // Destroy(gameObject);
       // }

   // }

        public void Beep()
        {
            beeped = true;
            sourceBeep.Play();

        }

    public void Explode()
    {

        Explodeenemy = true;
            source.Play();
            Instantiate(explosionEffect, transform.position, transform.rotation);
            Collider[] coll = Physics.OverlapSphere(transform.position, BlowRadius);

            for (int i = 0; i < coll.Length; i++)
            {
                if (coll[i].gameObject.GetComponent<PlayerHealth>())
                {
                    //coll[i].gameObject.GetComponent<PlayerHealth>().health -= damage;
                    PlayerHealth.health -= damage;
                   // coll[i].gameObject.GetComponent<Rigidbody>().AddExplosionForce(expolsiveForce, transform.position, BlowRadius);
                }
            }
            three_point_wavespawner.Enemiesalive--;
            Debug.Log("boom");
            Destroy(gameObject, .5f);
        
        
    }

}

