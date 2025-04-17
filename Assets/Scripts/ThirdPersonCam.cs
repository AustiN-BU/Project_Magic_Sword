/*****************************************************************************
// File Name : ThirdPersonCam.cs
// Author : Austin Nelson
// Creation Date : April 7, 2025
//
// Brief Description : This is the code for the new Camera System, it was made using a tutorial from YouTube as a guide
so it can work with the new player movement script
*****************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform orientation;
    [SerializeField] private Transform player;
    [SerializeField] private Transform playerObj;
    [SerializeField] private Rigidbody rb;

    [SerializeField] private PlayerInput playerInput;
    private InputAction look;

    [SerializeField] private float rotationSpeed;

    private void Start()
    {
        look = playerInput.currentActionMap.FindAction("Look");
        Cursor.visible = false;
    }

    public void Update()
    {
        //rotates the orientation
        Vector3 viewDir = player.position - new Vector3(transform.position.x, transform.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;

        //rotates the player object
        float horizontalInput = look.ReadValue<Vector2>().x;
        float verticalInput = look.ReadValue<Vector2>().y;
        Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (inputDir != Vector3.zero)
        {
            orientation.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}
