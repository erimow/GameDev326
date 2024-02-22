using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CursorDestroyer : MonoBehaviour
{
    public float raycastDistance = 100f;
    public TMP_Text coinText;
    public int coins = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, raycastDistance))
            {
                GameObject hitObject = hit.collider.gameObject;

                if (hitObject.CompareTag("Finish")){
                    Destroy(hitObject);
                    Debug.Log("Object broken: " + hitObject.name);
                    coins++;
                    coinText.text = "x" + coins.ToString("D2");

                } 
            } 
        }
    } 
}
