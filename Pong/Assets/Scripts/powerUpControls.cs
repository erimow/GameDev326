using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpControls : MonoBehaviour
{
    public int frame = 0;
    public int delay = 10000;
    public GameObject reverse;
    public GameObject fast;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        frame++;
        if (frame%delay == delay-1)
        {
            float direction = Random.value > 0.5f ? 1f : -1f;
            if (direction == 1f)
            {
                Instantiate(reverse, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 5.5f), 1.5f), Quaternion.identity);
            }
            else
            {
                Instantiate(fast, new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 5.5f), 1.5f), Quaternion.identity);              
            }
        }

    }
}
