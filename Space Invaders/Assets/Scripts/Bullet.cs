using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bullet : MonoBehaviour
{
    public bool isEnemy;

    public float moveSpeed = .2f;

    private GameObject enemyController;
    // Start is called before the first frame update
    void Start()
    {
        enemyController = GameObject.Find("Enemies");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isEnemy)
            transform.Translate(0, -moveSpeed, 0);
        else
        {
            transform.Translate(0, moveSpeed ,0);
        }

        if (transform.position.y > 6f || transform.position.y <-5.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Trigger entered by: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy1") && !isEnemy)
        {
            GameObject.FindWithTag("GameController").GetComponent<ScoreController>().Score += 10;
            enemyController.GetComponent<EnemyController>().enemiesKilled++;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy2") && !isEnemy)
        {
            GameObject.FindWithTag("GameController").GetComponent<ScoreController>().Score += 20;
            enemyController.GetComponent<EnemyController>().enemiesKilled++;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy3") && !isEnemy)
        {
            GameObject.FindWithTag("GameController").GetComponent<ScoreController>().Score += 30;
            enemyController.GetComponent<EnemyController>().enemiesKilled++;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("UFO") && !isEnemy)
        {
            GameObject.FindWithTag("GameController").GetComponent<ScoreController>().Score += 100;
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Barrier"))
        {
            Destroy(other.gameObject); 
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Player") && isEnemy)
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        

        
        
    }

   
}
