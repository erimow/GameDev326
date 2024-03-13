using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public float moveDelay = 2f;

    public float moveDistance = .25f;
    public float delayDecrease = .2f;
    public int enemiesKilled = 0;

    private bool movingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(Move), 0f, moveDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Move()
    {
        if (movingRight && transform.position.x<.25f)
            transform.Translate(moveDistance, 0, 0);
        else if (movingRight && transform.position.x >= .25f)
        {
            transform.Translate(0, -moveDistance, 0);
            movingRight = false;
        }
        else if (!movingRight && transform.position.x > -8.75f)
        {
            transform.Translate(-moveDistance, 0, 0); 
        }
        else if (!movingRight && transform.position.x <= -8.75f)
        {
            transform.Translate(0, -moveDistance, 0);
            movingRight = true;
        }
        CancelInvoke(nameof(Move));
        if (enemiesKilled >= 55)
        {
            SceneManager.LoadScene("Credits");
        }
        InvokeRepeating(nameof(Move), moveDelay-(enemiesKilled*delayDecrease), moveDelay-(enemiesKilled*delayDecrease));
    }
}
