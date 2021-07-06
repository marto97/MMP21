using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller; 

    public float runSpeed = 20f;

    float horizontalMove = 0f;

    bool jump = false;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Horizontal", Mathf.Abs(Input.GetAxis("Horizontal")));

        if(Input.GetButtonDown("Jump"))
        {
            jump = true; 
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            runSpeed = 50f;
        }
        else
        {
            runSpeed = 20f;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

    }

    void FixedUpdate ()
    {
        //Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
