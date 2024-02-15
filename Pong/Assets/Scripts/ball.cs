using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float speedIncrement = 2f;
    private Rigidbody rb;
    public AudioSource audioSource;
    public AudioClip paddleHitSound;
    public AudioClip wallHitSound;
    public GameObject leftPaddle;
    public GameObject rightPaddle;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        float direction = Random.value > 0.5f ? 1f : -1f;

        float angle = Random.Range(-45f, 45f) * Mathf.Deg2Rad;
        Vector3 initialDirection = new Vector3(direction, Mathf.Sin(angle), 0f);
        rb.velocity = initialDirection * moveSpeed;
    }

    void Update()
    {       
        rb.velocity = rb.velocity.normalized * moveSpeed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            ContactPoint contact = collision.contacts[0];
            Vector3 paddlePosition = collision.gameObject.transform.position;
            float paddleHeight = collision.gameObject.transform.localScale.y;
            float hitPoint = (contact.point.y - paddlePosition.y) / paddleHeight;
            float angle = -hitPoint * Mathf.PI / 1.5f;

            Vector3 newDirection = new Vector3(Mathf.Sign(rb.velocity.x) * Mathf.Cos(angle), Mathf.Sin(angle), 0f);
            rb.velocity = newDirection.normalized * -moveSpeed;
            moveSpeed += speedIncrement;
            audioSource.PlayOneShot(paddleHitSound);
            float pit = Mathf.Clamp(moveSpeed/5f, 1f, 4f);
            audioSource.pitch += .1f;

        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Vector3 newDirection = rb.velocity;
            newDirection.y *= -1;
            rb.velocity = newDirection.normalized * moveSpeed;
            audioSource.PlayOneShot(wallHitSound);
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("reverse"))
                {
                    if (rb.velocity.x > 0)
                    {
                        rightPaddle.GetComponent<paddles>().moveSpeed*=-1;
                    }
                    else
                    {
                        leftPaddle.GetComponent<paddles>().moveSpeed*=-1;
                    }
                    Destroy(other.gameObject);
                }
        if (other.gameObject.CompareTag("fast"))
        {
            if (rb.velocity.x < 0)
                    {
                        rightPaddle.GetComponent<paddles>().moveSpeed*=2;
                    }
                    else
                    {
                        leftPaddle.GetComponent<paddles>().moveSpeed*=2;
                    }
                    Destroy(other.gameObject);
        }
    }

}