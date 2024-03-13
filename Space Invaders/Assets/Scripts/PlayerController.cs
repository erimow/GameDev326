using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public Transform shootPoint;
    public GameObject bullet;
    private Animator anim;
    private AudioSource audi;
    public bool bulletAlive = false;
    public AudioClip shoot;
    public AudioClip die;
    private ParticleSystem part;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
        part = GetComponentInChildren<ParticleSystem>();
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
                    part.Play();
                    audi.PlayOneShot(shoot);
                    anim.SetTrigger("Shooting");
                    backToIdle();
                }
    }

    void backToIdle()
    {
        anim.SetTrigger("BackToIdle");
    }

    public void triggerDie()
    {
        anim.SetTrigger("Die");
        audi.PlayOneShot(die);
    }

    public void Die()
    {
        SceneManager.LoadScene("Credits");
       Destroy(this.gameObject); 
    }
}
