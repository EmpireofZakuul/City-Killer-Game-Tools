using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpact : MonoBehaviour
{
    public Transform target;
    public float speed = 70f;
    public static int BulletDamage;
    public int damage = 10;
  

    public void Start()
    {
        BulletDamage = damage;
    }
    public void aim(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }
    void HitTarget()
    {
        //  GameObject blast = (GameObject)Instantiate(bulleteffect, transform.position, transform.rotation);
        //  Destroy(blast, 2f);

          
        

        //  Damage(target);
        //Destroy(gameObject);

    }


    public void OnTriggerEnter(Collider other)
    {



        PlayerHealth.health -= 10f;
        Destroy(gameObject);
    }
}
