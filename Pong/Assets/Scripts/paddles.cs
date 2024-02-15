using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paddles : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float maxVelocity = 10f; 
    public bool left = false;
    public bool right = false;
    public bool npc = false;
    public GameObject ball;

    private Rigidbody rb;
    private float moveInput = 0.0f;
    private float dir = 0;
    private int frame = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation; // Freeze rotation and restrict movement to the x and z axes
    }

    void FixedUpdate()
    {
        if (left)
            moveInput = Input.GetAxisRaw("Vertical");
        else if (right)
            moveInput = Input.GetAxisRaw("AKeys");
        
        Vector3 moveVelocity = rb.velocity;
        if(!npc)
        {
            if (Mathf.Abs(moveVelocity.y) < maxVelocity)
            {
                moveVelocity.y += moveInput * moveSpeed;
            }  
        }
        else
        {
            float ballY = ball.transform.position.y;
            if (ballY > this.transform.position.y)
                dir = 1;
            else
                dir = -1;

            if (Mathf.Abs(moveVelocity.y) < maxVelocity)
            {
                moveVelocity.y += dir * moveSpeed;
            }
        }
        rb.velocity = moveVelocity;
        if(moveSpeed<0f)
        {
            if (frame%150==149)
            {
                moveSpeed = 5f;
            }
            frame++;
            print(frame%150);
        }
        else if(moveSpeed>5f)
        {
            if (frame%150==149)
            {
                moveSpeed = 5f;
            }
            frame++;
            print(frame%150);
        }
    }
}