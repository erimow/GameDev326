using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnableGameOver : MonoBehaviour
{
    public GameObject GameOverUI;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).length >
            anim.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            GameOverUI.SetActive(true);
        }
    }
}
