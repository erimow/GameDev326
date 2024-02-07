using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evilPaddle : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float maxVelocity = 10f;
    public GameObject ball;

    private Rigidbody rb;
    private float dir = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation; // Freeze rotation and restrict movement to the x and z axes
    }

    void FixedUpdate()
    {

        float ballY = ball.transform.position.y;
        if (ballY > this.transform.position.y)
            dir = 1;
        else
            dir = -1;

        Vector3 moveVelocity = rb.velocity;

        if (Mathf.Abs(moveVelocity.y) < maxVelocity)
        {
            moveVelocity.y += dir * moveSpeed;
        }

        rb.velocity = moveVelocity;
    }
}
