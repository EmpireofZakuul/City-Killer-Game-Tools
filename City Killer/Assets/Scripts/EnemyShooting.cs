using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   

public class EnemyShooting : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public float attackDistance = 10f;
    public float followDistance = 20f;

    [Range(0.0f, 1.0f)]
    public float attackProbality = 0.5f;

    [Range(0.0f, 1.0f)]
    public float hitAccuracy = 0.5f;
    public float damagePoints = 2f;
    public AudioClip gunShot;
    public AudioSource AudioSource;
    NavMeshAgent nav;

    public GameObject bullet;
    private float timerShots;
    public float timeBetweenShots = 0.25f;
    public float fireRadius = 25f;
    public float force = 100f;

    // Start is called before the first frame update
    void Start()
    {
      
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);
        if(distance <= fireRadius)
        {
            AIShoot();
        }
    }

    public void AIShoot()
    {
        animator.SetBool("Shoot", true);
        RaycastHit hitPlayer;
        Ray playerPos = new Ray(transform.position, transform.forward);
        if(Physics.SphereCast(playerPos, 025f, out hitPlayer , fireRadius))
        {
            if(timerShots <= 0 &&  hitPlayer.transform.tag == "Player")
            {
                GameObject BulletHolder;
                BulletHolder = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
                BulletHolder.transform.Rotate(Vector3.left * 90);

                Rigidbody rigidbody;
                rigidbody = BulletHolder.GetComponent<Rigidbody>();
                rigidbody.AddForce(transform.forward * force);

                Destroy(BulletHolder, 2.0f);
                timerShots = timeBetweenShots;
            }
            else
            {
                timerShots = Time.deltaTime;
            }
        }
    }
}


