using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 10f;

    private float xInput;
    private float zInput;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    } // Start

    private void Update()
    {
        InputProgress();
    } // Update

    void FixedUpdate()
    {
        Move();
    } // Fixed Update

    private void InputProgress()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        rb.AddForce(new Vector3(xInput,0f,zInput) * moveSpeed);
    }
    
}
