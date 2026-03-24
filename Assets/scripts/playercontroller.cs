using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontroller : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    // Speed at which the player moves.
    public float speed = 0;

    // Camera follow fields
    public Transform cameraTransform;     // Drag Main Camera here
    public Vector3 cameraOffset = new Vector3(0, 10, -10);
    public float cameraSmooth = 0.125f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void FixedUpdate()
    {
        // Get camera's forward and right directions (flattened to ground plane)
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();
        
        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();
        
        // Calculate movement relative to camera direction
        Vector3 movement = (cameraForward * movementY + cameraRight * movementX);
        
        rb.AddForce(movement * speed);
    }

    void LateUpdate()
    {
        // Smooth camera follow
        Vector3 desiredPos = transform.position + cameraOffset;
        Vector3 smoothedPos = Vector3.Lerp(cameraTransform.position, desiredPos, cameraSmooth);

        cameraTransform.position = smoothedPos;
        cameraTransform.LookAt(transform);
    }
}
