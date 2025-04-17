/*****************************************************************************
// File Name : PlayerMovement.cs
// Author : Austin Nelson
// Creation Date : April 9, 2025
//
// Brief Description : This is the code for the new Player Movement System, made using a different tutorial so it can work with a camera.
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;


    [Header("Check Ground")]
    public float playerHeight;
    public LayerMask Ground;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    [Header("Health")]
    [SerializeField] private int healAmount;

    //new input
    private PlayerInput playerInput;
    private InputAction jump;
    private InputAction move;
    private InputAction heal;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        playerInput = GetComponent<PlayerInput>();
        jump = playerInput.currentActionMap.FindAction("Jump");
        move = playerInput.currentActionMap.FindAction("Move");
        heal = playerInput.currentActionMap.FindAction("Heal");
        jump.started += Jump_started;
        heal.started += Heal_started;
    }

    private void Heal_started(InputAction.CallbackContext obj)
    {
        GetComponentInChildren<Health>().Heal(healAmount);
    }

    private void Jump_started(InputAction.CallbackContext obj)
    {
        if (grounded)
        {
         Jump();
        }
 
    }

    private void Update()
    {
        //checks for the ground
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, Ground);

        MyInput();

        //handles drag
        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 1;
        
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }



    private void MyInput()
    {

        horizontalInput = move.ReadValue<Vector2>().x;
        verticalInput = move.ReadValue<Vector2>().y;
       
    }

    private void MovePlayer()
    {
        //calculates movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        moveDirection.y = 0;

        //on the ground
        if(grounded)
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        //in the air
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * 10f);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limits velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        //resets y velocity

        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }


}
