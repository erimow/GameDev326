using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bullet;

    public int shootOdds = 1000;

    private Animator anim;
    private AudioSource audi;

    public AudioClip shoot;

    public AudioClip death;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.Range(0, shootOdds) == 0)
        {
            anim.SetTrigger("Shoot");
            
        }
    }

    public void triggerDie()
    {
        anim.SetTrigger("Die");
        audi.PlayOneShot(death);
    }

    public void backToIdle()
    {
        anim.SetTrigger("ToIdle");
    }
    public void Die()
    {
        
        Destroy(this.gameObject);
    }

    public void Shoot()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        audi.PlayOneShot(shoot);
    }
}
