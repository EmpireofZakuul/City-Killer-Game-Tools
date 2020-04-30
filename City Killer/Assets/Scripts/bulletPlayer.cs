using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayer : MonoBehaviour
{
    public static int BulletDamage;
    public int damage = 10;
    void Start()
    {
        
    }

   

// Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 4f);
    }
    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            EnemyHealth.health -= 12f;
        }

        if (other.gameObject.tag == "Player")
        {
            PlayerHealth.health -= 12f;
        }

    }


}
