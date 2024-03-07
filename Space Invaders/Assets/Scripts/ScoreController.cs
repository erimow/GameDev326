using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreController : MonoBehaviour
{
    public int Score = 0;
    public int HighScore = 0;
    public TMP_Text score;
    public TMP_Text hScore;
    public GameObject overlay;
    public GameObject UFO;
    public float UFODelay = 15f;
    
    // Start is called before the first frame update
    void Start()
    {
        HighScore = PlayerPrefs.GetInt("HighScore", 0);
        hScore.text = "HighScore:\n" + HighScore.ToString("D4");
        InvokeRepeating(nameof(spawnUFO), UFODelay, UFODelay);
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score:\n" + Score.ToString("D4");
        if (Score >= HighScore)
        {
            setHighScore();
            hScore.text = "HighScore:\n" + HighScore.ToString("D4");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle pause/unpause when the 'P' key is pressed
            if (Time.timeScale == 0)
            {
                // If time is already paused, resume it
                overlay.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                // If time is not paused, pause it
                overlay.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    private void spawnUFO()
    {
        Instantiate(UFO, new Vector3(-10, 4.35f, 0), Quaternion.identity);
    }

    private void setHighScore()
    {
        HighScore = Score;
        PlayerPrefs.SetInt("HighScore", HighScore);
    }
}
