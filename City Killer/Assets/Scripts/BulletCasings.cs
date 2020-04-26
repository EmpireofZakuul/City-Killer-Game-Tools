using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCasings : MonoBehaviour
{
    public GameObject bulletCasings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Instantiate(bulletCasings, transform.position, transform.rotation);
        }
    }
}
