using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //DontDestroyOnLoad(this);
    }

    void Start()
    {
        
    }

    public void StartGame()
    {
        StartCoroutine(FindPlayer());
    }

    IEnumerator FindPlayer()
    {
        AsyncOperation asyncOp = SceneManager.LoadSceneAsync("Game");
        while (!asyncOp.isDone)
            yield return null;
        
        GameObject playerObj = GameObject.Find("Player");
        Debug.Log(playerObj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play() 
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }
}
