using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DieSpace : MonoBehaviour
{
    int Life = 10;
    public GameObject respawn;
    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            Life = Life - 1;
            if (Life <= 0)
            {
                Invoke("Respawn", 2);
            }
            //System.Threading.Thread.Sleep(500);
            //yield return new WaitForSeconds(0.1f);
            //other.transform.position = respawn.transform.position;
            
        }
    }
    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, Screen.width/7, Screen.height/15), "Life = " + Life);
    }
    void Respawn()
    {
        Application.LoadLevel(Application.loadedLevel);
        //other.transform.position = respawn.transform.position;
    }*/

}
