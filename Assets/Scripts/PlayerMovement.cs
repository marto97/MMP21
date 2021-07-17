using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;

    public float moveSpeed;
    public float walkSpeed;
    public float runSpeed;

    float horizontalMove = 0f;

    bool jump = false;

    public Animator animator;

    void Start()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene ();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "level_4")
        {
            walkSpeed = 50f;
            runSpeed = 150f;
        }
        else
        {
            walkSpeed = 20f;
            runSpeed = 50f;
        }
    }

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
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }
        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

    }

    void FixedUpdate ()
    {
        //Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}
