using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public float lookRadius = 10f;
    NavMeshAgent nav;
    public Transform target;
    private bool targetFound;
    public GameObject Base;
    public GameObject player;
    public float startspeed = 5f;
    public float range = 5f;
    public float Speed;
    public Transform playerCharacter;
    // Start is called before the first frame update
    void Start()
    {
        nav.GetComponent<NavMeshAgent>();
        Base = GameObject.FindGameObjectWithTag("Base");
        Speed = startspeed;
    }

    // Update is called once per frame
    void Update()
    {
        Speed = startspeed;
       // nav.destination = Base.transform.position;
        nav.destination = playerCharacter.position;
        float distanceToEnemy = Vector3.Distance(transform.position, player.transform.position);
        //if (distanceToEnemy < range)
        //{
           // nav.destination = player.transform.position;
       // }
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Base")
        {
            // stats.Health--;
            waveSpawner.Enemiesalive--;
            Destroy(gameObject);
        }
       
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
