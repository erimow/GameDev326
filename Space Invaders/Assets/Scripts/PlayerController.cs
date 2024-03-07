using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Transform shootPoint;
    public GameObject bullet;
    private Animator anim;
    public bool bulletAlive = false;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //move player left
            this.transform.Translate(new Vector3(0, MoveSpeed ,0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(new Vector3(0,  -MoveSpeed,0)); 
        }

       
    }

    void Update()
    {
        if (GameObject.FindWithTag("PlayerBullet") != null)
        {
            bulletAlive = true;
        }
        else
        {
            bulletAlive = false;
        }
         if (Input.GetKeyDown(KeyCode.Space) && !bulletAlive)
                {
                    Instantiate(bullet, shootPoint.position, Quaternion.identity);
                    anim.SetTrigger("Shooting");
                    backToIdle();
                }
    }

    void backToIdle()
    {
        anim.SetTrigger("BackToIdle");
    }
}
