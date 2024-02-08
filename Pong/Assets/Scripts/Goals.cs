using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Goals : MonoBehaviour
{
    public int score=0;
    public TMP_Text textBox;
    public GameObject gameOver;
    public bool left = false;
    public bool right = false;

    void Update()
    {
        if (gameOver.active)
        {
            score=0;
            textBox.text = "0";
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            score++;
            textBox.text = score.ToString();
            
            //Reset Pos
            other.gameObject.transform.position = new Vector3(0f, 1f, 1.5f);

            // Reset Speed
            other.gameObject.GetComponent<ball>().moveSpeed = 5f;

            if(left)
                print("Right scored | Now has : " + score + " points.");
            else
                print("Left scored | Now has : " + score + " points.");
            
            // Rigidbody puckRigidbody = other.gameObject.GetComponent<Rigidbody>();
            // if (puckRigidbody != null)
            // {
            //     puckRigidbody.velocity = -puckRigidbody.velocity;
            // }
        }
        if (score == 11)
        {
            gameOver.SetActive(true);
            if (left){
                gameOver.GetComponent<TMP_Text>().text = "Game Over : Right Wins";
                print("Game Over : Right Wins");
            }
            else if (right)
                gameOver.GetComponent<TMP_Text>().text = "Game Over : Left Wins";
                print("Game Over : Left Wins");
        }
    }
}
