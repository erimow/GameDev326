using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 25f;
    public float maxSpeed = 25f;

    public float jumpImpulse = 5f;
    public float jumpBoost = 3f;

    public bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        Rigidbody rbody = GetComponent<Rigidbody>();
        rbody.velocity += Vector3.right * horizontalMovement * Time.deltaTime * speed;
        

        Collider col = GetComponent<Collider>();
        float halfHeight = col.bounds.extents.y + 0.03f;
        
      

        Vector3 startPoint = transform.position;
        Vector3 endPoint = startPoint + Vector3.down * 2f;
        isGrounded = Physics.Raycast(startPoint, Vector3.down, halfHeight);
        Color lineColor = (isGrounded) ? Color.red : Color.blue;
        Debug.DrawLine(startPoint, endPoint, lineColor, 0f, false);
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rbody.AddForce(Vector3.up * jumpImpulse, ForceMode.Impulse);
        }
        else if(!isGrounded && Input.GetKey(KeyCode.Space))
        {
            if (rbody.velocity.y > 0)
                rbody.AddForce(Vector3.up * jumpBoost, ForceMode.Force);
        }

        
        if (Math.Abs(rbody.velocity.x) > maxSpeed)
        {
            Vector3 newVel = rbody.velocity;
            newVel.x = Math.Clamp(newVel.x, -maxSpeed, maxSpeed);
            rbody.velocity = newVel;
        }
        if (isGrounded && Math.Abs(horizontalMovement) < .5f)
        {
            Vector3 newVel = rbody.velocity;
            newVel.x *= 1f - Time.deltaTime;
            rbody.velocity = newVel; 
        }
        float yaw = (rbody.velocity.x > 0) ? 90 : -90;
        transform.rotation = Quaternion.Euler(0f, yaw, 0f);
    }
}
