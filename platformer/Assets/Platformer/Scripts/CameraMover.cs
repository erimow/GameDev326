using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public float cameraMoveRate = 0.5f;

    private Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            this.transform.Translate(cameraMoveRate, 0, 0); 
        }
        else if (Input.GetKey(KeyCode.O))
        {
            this.transform.Translate(-cameraMoveRate, 0, 0);  
        }
    }
}
