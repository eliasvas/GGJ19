﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    Animator anim;
    public bool isOnDoor;
    public string scene;
    public bool CanOpen = false;

	// Use this for initialization
	void Start () {
        //anim = GetComponent<Animator>();
        //an CanOpen == false to allakse to sprite sto kanoniko
	}
	
	// Update is called once per frame
	void Update () {
        if (isOnDoor && Input.GetKeyDown(KeyCode.UpArrow) && CanOpen) {
            //anim.SetTrigger("Enter");
            StartCoroutine(LoadScene(scene));
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") {
            isOnDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player") {
            isOnDoor = false;
        }
    }
    IEnumerator LoadScene(string scene) {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(scene);
    }
}