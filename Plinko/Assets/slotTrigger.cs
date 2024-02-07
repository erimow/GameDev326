using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class slotTrigger : MonoBehaviour
{

    public int PointsGiven = 0;
    public GameObject scriptController;



    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            print("Points awarded: " + PointsGiven);
            Destroy(other.gameObject);
            scriptController.GetComponent<scoreController>().score+=PointsGiven;
        }
    }
}
