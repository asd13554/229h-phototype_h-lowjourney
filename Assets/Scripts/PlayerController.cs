using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public enum UnitState
{
    Idle,
    Move,
    Attack,
    Jump
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private UnitState state;
    public UnitState State { get { return state; } set { state = value; } }
    
    private NavMeshAgent navAgent;
    public NavMeshAgent NavAgent { get { return navAgent; } }
    
    
    
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
        //Player Jump
        if (Input.GetKeyDown(KeyCode.W))
        {
            SetState(UnitState.Jump);
            rb2D.AddForce(new Vector2(0,jump), ForceMode2D.Impulse);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            SetState(UnitState.Attack);
        }

    } // Update

    void FixedUpdate()
    {
        InputProgress();
    } // Fixed Update
    
    public void SetState(UnitState toState)
    {
        state = toState;
    }

    private void InputProgress()
    {
        xInput = Input.GetAxis("Horizontal");
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            SetState(UnitState.Idle);
            return;
        }
        SetState(UnitState.Move);
        Move();
        
        if (Input.GetAxisRaw("Horizontal") != 0)
            transform.right = Input.GetAxisRaw("Horizontal") < 0 ? Vector2.left : Vector2.right;
    }

    private void Move()
    {
        rb2D.AddForce(new Vector3(xInput,0f,zInput) * moveSpeed * Time.deltaTime);
        rb2D.velocity = new Vector2(xInput * moveSpeed, rb2D.velocity.y);
        SetState(UnitState.Move);
        
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
        
        //Player Die
        if (Col.gameObject.tag == "Enemy")
        {
            Col.gameObject.SetActive(false);
            ScoreManager.instance.AddPoint();
        }
    }

}
