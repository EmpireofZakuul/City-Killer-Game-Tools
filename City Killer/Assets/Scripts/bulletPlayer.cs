using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlayer : MonoBehaviour
{
   
    public static int BulletDamage;
    public int damage = 1;

    public static int Damage;
    public int damagePlay = 3;
  

    private Transform enemy;
    void Start()
    {
        BulletDamage = damage;
        Damage = damagePlay;
      

    }




    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 4f);
    }

  
    public void OnTriggerEnter(Collider other)
    {
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();
        if (other.gameObject.tag == "Enemy")
        {
            if (enemy != null)
            {
               
                enemy.TakeDamage2(damage);
             
                Destroy(gameObject, .1f);
               
            }
        }
       
    
        if (other.gameObject.tag == "Player")
        {
            PlayerHealth.health -= damagePlay;
        }
        

    }
    


}
