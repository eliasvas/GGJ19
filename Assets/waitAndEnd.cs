using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class waitAndEnd : MonoBehaviour {

    public float seconds;
	// Use this for initialization
	void Start () {
        StartCoroutine(Wait());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Wait() {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene("Menu");
    }
}
