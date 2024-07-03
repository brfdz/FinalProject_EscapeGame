using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    public CharacterController controller;
    public float speed;
    
    
    private Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    
    //crouch variables
    private float CrouchHeight = 0.7f;
    private float StandingHeight = 2.5f;
    private bool isCrouching;
    private KeyCode crouchKey = KeyCode.C;

    private void Awake()
    {
        SetGroundCheck();
    }


    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        HandleMovement();
        HandleGravity();
        HandleCrouch();
    }

    private void SetGroundCheck()
    {
        groundCheck.localPosition = new Vector3(controller.center.x, controller.center.y - controller.height / 2, controller.center.z);
    }

    private void HandleMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
    }

    private void HandleGravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        //apply gravity
        velocity.y += gravity /2f  * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void HandleCrouch()
    {
        if (Input.GetKeyDown(crouchKey))
        {
            if (!isCrouching)
            {
                controller.height = CrouchHeight;
                SetGroundCheck();
                isCrouching = true;
            }
            else
            {
                controller.height = StandingHeight;
                SetGroundCheck();
                isCrouching = false;
            }
        }
    }
}
