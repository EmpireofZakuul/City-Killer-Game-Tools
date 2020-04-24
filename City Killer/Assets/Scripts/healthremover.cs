using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthremover : MonoBehaviour
{
   // public float damageAmount = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter (Collider other)
    {

        if (other.gameObject.tag=="Player"){
            PlayerHealth.health -= 10f;
        }
      

           
        
    }
}
