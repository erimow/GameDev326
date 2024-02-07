using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreController : MonoBehaviour
{
    public int score = 0;
    public TMP_Text textbox;

    // Update is called once per frame
    void Update()
    {
        textbox.text = "Score: " + score.ToString();
    }
}
