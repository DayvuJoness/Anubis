using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAnimatoin : MonoBehaviour
{
    public int timer = 0;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();


    }
    public void EndOfAnimatoin()
    {
        SceneManager.LoadScene("Menu");
    }
    private void Update()
    {
        anim.SetInteger("Play", timer);
        timer = 1;
        if (timer == 1)
        {
            //SceneManager.LoadScene("Menu");
        }
    }
}
