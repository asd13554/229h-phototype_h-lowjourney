using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnimation : MonoBehaviour
{
    private Animator anim;
    private PlayerController unit;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        unit = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ChooseAnimation(unit);
    }
    
    private void ChooseAnimation(PlayerController u)
    {
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsMove", false);
        anim.SetBool("IsAttack", false);
        anim.SetBool("IsJump", false);

        switch (u.State)
        {
            case UnitState.Idle:
                anim.SetBool("IsIdle", true);
                break;
            case UnitState.Move:
                anim.SetBool("IsMove", true);
                break;
            case UnitState.Attack:
                anim.SetBool("IsAttack", true);
                break;
            case UnitState.Jump:
                anim.SetBool("IsJump", true);
                break;
        }
    }
}