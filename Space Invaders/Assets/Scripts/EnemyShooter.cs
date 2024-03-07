using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject bullet;

    public int shootOdds = 1000;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Random.Range(0, 1000) == 0)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
        }
    }
}
