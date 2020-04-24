using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public Transform Base;


    public float startspeed = 5f;
    public float range = 5f;
    private float Health;
    public float Speed;

    public Animator Animator;
   


    //ai view
    public bool PlayerLineOfSight = false;
    public float aiFieldOfView = 160f;
    public float lineOfSightRadius = 45f;
    //ai memory
    private bool aiMemerizesPlayerPosition = false;
    public float memoryStartTime = 10f;
    private float increaseMemoryTime;
    //ai noise
    Vector3 noisePosition;
    private bool aiHeardPlayer = false;
    public float noiseTravelDistance = 50f;
    public float spinSpeed = 3f;
    private bool canSpin = false;
    private float isSpinningTime;
    public float spinTime = 3f;

    //waypoints
    public Transform[] waypoints;
    private int randomWaypoints;
    NavMeshAgent nav;

    private float waitTime;
    public float startWaitTime = 1f;
    //ai movement 
    public float distanceToPlayer = 5.0f;
    private float randomStrafeStartTime;
    private float waitStrafeTime;
    public float t_minStrafe;
    public float t_maxStrafe;

    public float chaseRadius = 20f;
    public float facePlayerFactor = 20f;

    public Transform strafeRight;
    public Transform strafeLeft;
    private int randomStrafeDir;
    // public Image HeathBar;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
        
    }


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomWaypoints = Random.Range(0, waypoints.Length);
        Animator = GetComponent<Animator>();
    }

    // Descision tree
    void Update()
    {
       
        float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);

        if (distance <= lineOfSightRadius)
        {

            CheckLos();//check line of sight
        }
        if (nav.isActiveAndEnabled)
        {
            if (PlayerLineOfSight == false && aiMemerizesPlayerPosition == false && aiHeardPlayer == false)
            {
                Patrol();
                NoiseCheck();
                StopCoroutine(AiMemory());
            }
            else if (aiHeardPlayer == true && PlayerLineOfSight == false && aiMemerizesPlayerPosition == false)
            {
                canSpin = true;
                GoToNoisePoisition();//go to the noise position 
            }
            else if (PlayerLineOfSight == true)
            {
                aiMemerizesPlayerPosition = true;
                ChasePlayer();
                FacePlayer();
            }
            else if (aiMemerizesPlayerPosition == true && PlayerLineOfSight == false)
            {
                ChasePlayer();
                StartCoroutine(AiMemory());
            }
        }
        player = GameObject.FindGameObjectWithTag("Player");
       


    }

    //enemy hears the player
    void NoiseCheck()
    {
        float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);

        if (distance <= noiseTravelDistance)
        {
            if (Input.GetButton("Fire1"))
            {
                noisePosition = PlayerMovement.playerPos;//noise poidion is player position
                aiHeardPlayer = true;
            }
            else
            {
                aiHeardPlayer = false;
                canSpin = false;
            }
        }
    }

    //ai moves to the noise
    void GoToNoisePoisition()
    {
        nav.SetDestination(noisePosition);

        if (Vector3.Distance(transform.position, noisePosition) <= 5f && canSpin == true)
        {
            isSpinningTime += Time.deltaTime;
            transform.Rotate(Vector3.up * spinSpeed, Space.World);

            if (isSpinningTime >= spinTime)
            {
                canSpin = false;
                aiHeardPlayer = false;
                isSpinningTime = 0f;
            }
        }
    }

    //check line of sight
    void CheckLos()
    {
        Vector3 direection = PlayerMovement.playerPos - transform.position;
        float angle = Vector3.Angle(direection, transform.forward);

        if (angle < aiFieldOfView * 0.5f)//if player is in view
        {
            RaycastHit hit;//hit player with raycast

            if (Physics.Raycast(transform.position, direection.normalized, out hit, lineOfSightRadius))
            {
                if (hit.collider.tag == "Player")
                {
                    PlayerLineOfSight = true;
                    aiMemerizesPlayerPosition = true;

                }
                else
                {
                    PlayerLineOfSight = false;
                }
            }
        }
    }

    IEnumerator AiMemory()
    {
        increaseMemoryTime = 0f;
        while (increaseMemoryTime < memoryStartTime)
        {
            increaseMemoryTime += Time.deltaTime;
            aiMemerizesPlayerPosition = true;
            yield return null;

        }
        aiHeardPlayer = false;
        aiMemerizesPlayerPosition = false;
    }

    //ai moves randomly between the waypoints
    void Patrol()
    {
        Animator.SetBool("Run", true);
        nav.SetDestination(waypoints[randomWaypoints].position);
        if (Vector3.Distance(transform.position, waypoints[randomWaypoints].position) < 2.0f)
        {
            if (waitTime <= 0)
            {
                randomWaypoints = Random.Range(0, waypoints.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        
        //nav.SetDestination(Base.position);



    }

    void ChasePlayer()
    {
        float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);
        if (distance <= chaseRadius && distance > distanceToPlayer)
        {
            nav.SetDestination(PlayerMovement.playerPos);

        }
        else if (nav.isActiveAndEnabled && distance <= distanceToPlayer)
        {
            randomStrafeDir = Random.Range(0, 2);
            randomStrafeStartTime = Random.Range(t_minStrafe, t_maxStrafe);

            if (waitStrafeTime <= 0)
            {
                if (randomStrafeDir == 0)
                {
                    nav.SetDestination(strafeLeft.position);
                }
            }
            else if (randomStrafeDir == 1)
            {
                nav.SetDestination(strafeRight.position);
            }
            waitStrafeTime = randomStrafeStartTime;


        }
        else
        {
            waitStrafeTime -= Time.deltaTime;
        }
    }

    void FacePlayer()
    {
        Vector3 direction = (PlayerMovement.playerPos - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerFactor);
    }

    public void LateUpdate()
    {
        if(aiMemerizesPlayerPosition ==  true && PlayerLineOfSight == false)
        {
            distanceToPlayer = 0.5f;
        }
        else
        {
            distanceToPlayer = 10.0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Base")
        {
            //EnemyHealth.Health--;

            Destroy(gameObject);
        }
    }
}



