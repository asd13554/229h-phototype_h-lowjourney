using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float moveSpeed = 10f;
    public float jump = 5;

    public float Drop = -20f;

    private float xInput;
    private float zInput;
    
    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();

    } // Start

    private void Update()
    {
        InputProgress();
        
        //Player Jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb2D.AddForce(new Vector2(0,jump), ForceMode2D.Impulse);
        }
        
    } // Update

    void FixedUpdate()
    {
        Move();
    } // Fixed Update

    private void InputProgress()
    {
        xInput = Input.GetAxis("Horizontal");
    }

    private void Move()
    {
        rb2D.AddForce(new Vector3(xInput,0f,zInput) * moveSpeed * Time.deltaTime);
        rb2D.velocity = new Vector2(xInput * moveSpeed, rb2D.velocity.y);

        //Respawn player to Original Position
        if (transform.position.y < Drop)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D Col)
    {
        //Get Goal and move to Credit Scene
        if (Col.gameObject.name == "Finish")
        {
            SceneManager.LoadScene(2);
        }
        
        //Get Score from Token
        if (Col.gameObject.tag == "Token")
        {
            Col.gameObject.SetActive(false);
            ScoreManager.instance.AddPoint();
        }
    }

}
