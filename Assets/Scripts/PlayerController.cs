/*****************************************************************************
// File Name : PlayerController.cs
// Author : Austin Nelson
// Creation Date : March 25, 2025
//
// Brief Description : This controls player movement and jumping, It was made using a tutorial.          
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    [SerializeField] float moveSpeed = 0f;
    Vector2 moveInput;
    Vector3 movement;


    float jumpSpeed = 15f;
    float jumpGravity = 0.75f;
    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        if (characterController.isGrounded && !isJumping) isJumping = true;
    }
 
   

    //This translates directional values along with controlling jumps.
    private void FixedUpdate()
    {
        movement.x = moveInput.x * moveSpeed;
        movement.z = moveInput.y * moveSpeed;

        if (characterController.isGrounded)
        {
            movement.y = -jumpGravity * 0.1f;

            if (isJumping)
            {
                movement.y = jumpSpeed;
                isJumping = false;
            }
        }
        else
        {
            movement.y -= jumpGravity * (movement.y > 0 ? 1 : 1.25f);
        }

            characterController.Move(movement * Time.fixedDeltaTime);
    }
}
