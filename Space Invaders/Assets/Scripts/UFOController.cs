using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOController : MonoBehaviour
{
    public float Speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Speed, 0 ,0);
        if (transform.position.x > 9.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
