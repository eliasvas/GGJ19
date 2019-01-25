using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

    public bool SceneFinished;
    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent <Animator>();    	
	}
	
	// Update is called once per frame
	void Update () {
        if (SceneFinished)
            anim.SetTrigger("finish");
	}
}
