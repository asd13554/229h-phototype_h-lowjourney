using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnusJump : MonoBehaviour
{
    private Rigidbody rb;
    public Vector3 angularV, sVelocity;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }// Start

    private void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Plate")
        {
            rb.angularVelocity = angularV;
            rb.velocity = sVelocity;
        }
        rb.AddForce( Vector3.Cross ( rb.angularVelocity , rb.velocity ) );
    }
}
