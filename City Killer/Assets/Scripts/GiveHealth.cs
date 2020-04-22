using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveHealth : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collison)
    {


        if (collison.tag == "Player")
        {
            PlayerHealth.health += 25f;
            Destroy(gameObject);
        }
    }  }
