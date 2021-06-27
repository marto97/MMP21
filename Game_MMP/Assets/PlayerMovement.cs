using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller; 

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            jump = true; 
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            runSpeed = 400f;
        }
        else
        {
            runSpeed = 40f;
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
