using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnImpact : MonoBehaviour
{
    public GameObject impact;
    public float damage = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Instantiate(impact, contact.point, Quaternion.LookRotation(contact.normal));

        if(collision.gameObject.tag == "Enemy")
        {
           // EnemyTarget target = collision.transform.gameObject.GetComponent<EnemyTarget>();
            //target.ApplyDamage(damage);
        }
    }
}
