using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed of the puck movement
    public float speedIncrement = 2f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Start the puck moving in a random direction
        Vector3 initialDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
        rb.velocity = initialDirection * moveSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            // Calculate new direction based on where it hits the paddle
            ContactPoint contact = collision.contacts[0];
            Vector3 paddlePosition = collision.gameObject.transform.position;
            float paddleHeight = collision.gameObject.transform.localScale.y;
            float hitPoint = (contact.point.y - paddlePosition.y) / paddleHeight;
            float angle = -hitPoint * Mathf.PI / 1.5f; // Angle range [-pi/4, pi/4]

            Vector3 newDirection = new Vector3(Mathf.Sign(rb.velocity.x) * Mathf.Cos(angle), Mathf.Sin(angle), 0f);
            rb.velocity = newDirection.normalized * -moveSpeed;
            moveSpeed+=speedIncrement;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            // Calculate new direction by flipping the y direction
            Vector3 newDirection = rb.velocity;
            newDirection.y *= -1;
            rb.velocity = newDirection.normalized * moveSpeed;
        }
    }
}