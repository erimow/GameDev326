using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour
{
    public float timeTilRemoval = 1600f;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeTilRemoval--;
        if (timeTilRemoval <= 0)
        {
            timeTilRemoval = 1600f;
            this.gameObject.SetActive(false);
        }
    }
}
