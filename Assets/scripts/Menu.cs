using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 4f, Screen.height / 3,Screen.width/5, Screen.height/10), "Start")) {
            SceneManager.LoadScene("Start1");
        }
        if (GUI.Button(new Rect(Screen.width / 4f, Screen.height / 1.5f, Screen.width/5, Screen.height/10), "Controls"))
        {
            SceneManager.LoadScene("Controls");
        }
        if (GUI.Button(new Rect(Screen.width / 4f, Screen.height / 2f, Screen.width / 5, Screen.height / 10), "Credits"))
        {
            SceneManager.LoadScene("Ending");
        }
    }
}
