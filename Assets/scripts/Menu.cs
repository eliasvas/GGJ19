using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 3,Screen.width/5, Screen.height/5), "Start")) {
            SceneManager.LoadScene("Start1");
        }
        if (GUI.Button(new Rect(Screen.width / 2.5f, Screen.height / 1.5f, Screen.width/5, Screen.height/5), "Exit"))
        {
            Application.Quit();
        }
    }
}
