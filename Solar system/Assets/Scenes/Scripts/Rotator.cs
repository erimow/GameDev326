using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float yawDegreePerSecond = 45f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTran = GetComponent<Transform>();
        myTran.Rotate(new Vector3(0f, yawDegreePerSecond * Time.deltaTime, 0f), Space.World);
    }
}
