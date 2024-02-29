using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBlock : MonoBehaviour
{
    private float num = -1f;
    private Renderer rend;
    private float timer = 0f;
    private float updateInterval = .5f;

    public bool isUsed = false;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if ( timer>= updateInterval && isUsed == false)
        {
            num+=.2f;
            rend.material.mainTextureOffset= new Vector2(0, num);
            timer = 0f;
            if (num == 1f)
            {
                num = -1;
            }
            
        }
        else if (isUsed)
        {
            rend.material.mainTextureOffset = new Vector2(0, .4f);
        }
    }
}
