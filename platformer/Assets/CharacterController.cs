using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterController : MonoBehaviour
{
    public float speed = 25f;
    public float maxSpeed = 25f;

    public float jumpImpulse = 5f;
    public float jumpBoost = 3f;

    public bool isGrounded = true;

    public bool hitObject = false;

    public TMP_Text coinText;

    public TMP_Text scoreText;

    public int coins = 0;

    public int score = 0;
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
        float halfHeight = col.bounds.extents.y + .03f;
        
      
        RaycastHit hit;
        Vector3 startPoint = transform.position;
        Vector3 endPoint = startPoint + Vector3.down * 2f;
        isGrounded = Physics.Raycast(startPoint, Vector3.down, out hit, halfHeight);
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

        
        if (isGrounded)
        {
            GameObject hitFloor = hit.collider.gameObject;
            if (hitFloor.CompareTag("Goomba"))
                Destroy(hitFloor);
        }

        //Vector3 UendPoint = startPoint + Vector3.up * 2f;
        
        hitObject = Physics.Raycast(startPoint, Vector3.up, out hit, halfHeight);
        if (hitObject)
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("?") && hitObject.GetComponent<QuestionBlock>().isUsed==false)
            {
                hitObject.GetComponent<QuestionBlock>().isUsed = true; 
                coins++;
                score += 100;
                coinText.text = "x" + coins.ToString("D2");
                scoreText.text = "MARIO\n" + score.ToString("D6");
                //Destroy(hitObject);
            }
            else if (hitObject.CompareTag("Brick"))
            {
                score += 100;
                scoreText.text = "MARIO\n" + score.ToString("D6");
                Destroy(hitObject);
            }

            Vector3 vel = rbody.velocity;
            vel.y = 0f;
            rbody.velocity = vel;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
            maxSpeed = 15f;
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            maxSpeed = 10f;
        
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
        float Speed = rbody.velocity.x;
        GetComponentInChildren<Animator>().SetFloat("Speed", Math.Abs(Speed));
        GetComponentInChildren<Animator>().SetBool("Grounded", isGrounded);
        //Debug.Log(Speed);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pole"))
        {
            Debug.Log("Level Completed");
        }
        else if (other.gameObject.CompareTag("Goomba"))
        {
            Debug.Log("Game over");
        }
    }
}
