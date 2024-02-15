using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rot = .5f;
    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.Rotate(0, 0, rot, Space.Self);
    }
}
