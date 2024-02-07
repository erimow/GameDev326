using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddles : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float maxVelocity = 10f; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation; // Freeze rotation and restrict movement to the x and z axes
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxisRaw("Vertical");
        Vector3 moveVelocity = rb.velocity;

        if (Mathf.Abs(moveVelocity.y) < maxVelocity)
        {
            moveVelocity.y += moveInput * moveSpeed;
        }

        rb.velocity = moveVelocity;
    }
}