using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goals : MonoBehaviour
{
    public int score=0;
    public TMP_Text textBox;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            score++;
            textBox.text = score.ToString();
            
            
            // Reset position
            other.gameObject.transform.position = new Vector3(0f, 1f, 0f);

            // Reset speed
            other.gameObject.GetComponent<ball>().moveSpeed = 5f;
            
            // Reverse direction
            Rigidbody puckRigidbody = other.gameObject.GetComponent<Rigidbody>();
            if (puckRigidbody != null)
            {
                puckRigidbody.velocity = -puckRigidbody.velocity;
            }
        }
    }
}
