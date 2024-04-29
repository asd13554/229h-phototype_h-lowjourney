using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InertiaTensor : MonoBehaviour
{
    private Rigidbody rbRotate;

    void Start()
    {
        rbRotate = GetComponent<Rigidbody>();
    }// Start
    
    void FixedUpdate()
    {
        rbRotate.angularVelocity = rbRotate.inertiaTensor;
    }// Update 
}
