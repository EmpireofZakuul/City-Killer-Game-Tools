using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForce : MonoBehaviour
{
    public GameObject bulletcasing;
    // Start is called before the first frame update
    public float thrust = 1.0f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

// Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.right * thrust);
        Destroy(gameObject, 1f);
    }
}
