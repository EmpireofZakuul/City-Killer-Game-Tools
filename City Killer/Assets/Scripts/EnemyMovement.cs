using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
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
            //Transform basePlayer;
    private GameObject Base;

 
    void Start()
        {
        Base = GameObject.FindGameObjectWithTag("Base");
        player = GameObject.FindGameObjectWithTag("Player");
        target = playerManager.instance.player.transform;
        //basePlayer = BaseManager.instance.Base.transform;
        nav.GetComponent<NavMeshAgent>();
            originalSpeed = maxSpeed;
            
          
    }

    // Update is called once per frame
    void Update()
    {
       
       // float distanceBase = Vector3.Distance(basePlayer.position, transform.position);
        //if (distanceBase >= lookRadius)
       // {
           // nav.SetDestination(basePlayer.position);
        //}

        // this all works, below this
        float distance = Vector3.Distance(target.position, transform.position);
    
      
        if (distance <= lookRadius)
        {
            nav.SetDestination(target.position);
        }

        if (distance <= stopRadius)
        {
            stopAgent();
           // Shooting();
        }

    }

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


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, stopRadius);
    }

   
}