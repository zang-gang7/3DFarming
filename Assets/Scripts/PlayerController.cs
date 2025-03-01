using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement Components
    private CharacterController controller;
    private Animator animator;

    private float moveSpeed = 4f;

    [Header("Movement System")]
    public float walkSpeed = 4f;
    public float runSpeed = 8f;

    void Start()
    {
        // Get movement components
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Runs the function that handles all movement
        Move();
    }

    public void Move()
    {
        // Get horizontal and vertical inputs as a number
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Direction in a normalised vector
        Vector3 dir = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 velocity = moveSpeed * Time.deltaTime * dir;

        // Is the sprint pressed down?
        if(Input.GetButton("Sprint"))
        {
            // Set the animation to run and increase our movespeed
            moveSpeed = runSpeed;
            animator.SetBool("Running", true);
        }
        else
        {
            // Set the animation to walk and decrease our movespeed
            moveSpeed = walkSpeed;
            animator.SetBool("Running", false);
        }

        // Check if there movement
        if(dir.magnitude >= 0.1f)
        {
            // Look towards that direction
            transform.rotation = Quaternion.LookRotation(dir);

            // Move
            controller.Move(velocity);
        }

        animator.SetFloat("Speed", velocity.magnitude);
    }
}
