using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamera : MonoBehaviour
{
    public float speed = 20;
 
    Vector2 lerpMouse;
 
    private void Update()
    {
        lerpMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
        lerpMouse = new Vector2(Mathf.Round(lerpMouse.x * 10.0f) * 0.1f, Mathf.Round(lerpMouse.y * 10.0f) * 0.1f);
        transform.position = Vector2.Lerp(transform.position, lerpMouse, speed * Time.deltaTime);
    }
}
