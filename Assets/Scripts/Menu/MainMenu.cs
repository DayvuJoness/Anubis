using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //public PlayerControll reset;
    //public bool reset;

    /*void Awake()
    {
        DontDestroyOnLoad(this);
    }*/
    public void NewGamePressed()
    {
        //reset = gameObject.GetComponent<PlayerControll>();
        //reset = true;
        PlayerPrefs.SetInt("Reset", 1);
        SceneManager.LoadScene("GameScene1");
    }
    public void PlayPressed()
    {
        //reset = gameObject.GetComponent<PlayerControll>();
        //reset = false;
        PlayerPrefs.SetInt("Reset", 0);
        SceneManager.LoadScene("GameScene1");
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
    public void SettingsPressed()
    {

    }
}
