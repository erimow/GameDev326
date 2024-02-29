using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public int timer = 100;
    public TMP_Text tmp;
    private TimeSpan currentTime;
    private DateTime endTime;
    void Start()
    {
       endTime = DateTime.Now.AddSeconds(timer);
    }

    // Update is called once per frame
    void Update()
    {
        tmp.text = "TIME\n" + ((int)currentTime.TotalSeconds).ToString("D3");
        TimeSpan elapsedTime = endTime - DateTime.Now;
        if (elapsedTime.TotalSeconds <= 0)
        {
            Debug.Log("Timer is at 0\nGame over");
        }

        currentTime = elapsedTime;
        
    }
}
