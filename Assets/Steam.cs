using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : MonoBehaviour {

    BoxCollider2D box;
    AudioSource audio;

	// Use this for initialization
	void Start () {
        AudioClip sound = (AudioClip)Resources.Load("geyzer2", typeof(AudioClip));
        audio = GetComponent<AudioSource>();
        if (sound != null)
            audio.clip = sound;
        else
            Debug.Log("no");
        box = GetComponent<BoxCollider2D>();
        box.enabled = false;
        StartCoroutine(Damage());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Damage() {
        while (true) {
            yield return new WaitForSeconds(1.4f);
            box.enabled = true;
            audio.Play();
            yield return new WaitForSeconds(0.8f);
            box.enabled = false;
        }
    }
}
