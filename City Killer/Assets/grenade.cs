using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade : MonoBehaviour
{
    public float BlowRadius = 15f;
    public float expolsiveForce = 20f;
    public float delay = 3f;
    private float countdown;
    bool hasexploded = false;
    public static int BulletDamage;
    public int damage = 1;
    public AudioSource source;
    public AudioClip shot;
    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0 && !hasexploded)
        {
            Explode();
            hasexploded = true;

            
        }

        
    }

    public void Explode()
    {
        source.Play();
        Collider[] coll = Physics.OverlapSphere(transform.position, BlowRadius);

        for (int i  = 0; i < coll.Length; i++)
        {
            if (coll[i].gameObject.GetComponent<EnemyHealth>())
            {
                 coll[i].gameObject.GetComponent<EnemyHealth>().TakeDamage2(damage);
                coll[i].gameObject.GetComponent<Rigidbody>().AddExplosionForce(expolsiveForce, transform.position, BlowRadius);
            }
        }
        
        Debug.Log("boom");
        Destroy(gameObject, 1f);
    }

   // private void OnDrawGizmosSelected()
   // {
        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, BlowRadius);

   // }

    /*public void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (other.gameObject.tag == "Enemy" && BlowRadius <= 0)
        {
            if (enemy != null)
            {
                enemy.TakeDamage2(damage);

                Destroy(gameObject, .1f);

            }
        }
    }
    */
}
