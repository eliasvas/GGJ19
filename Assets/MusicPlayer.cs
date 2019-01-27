using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public string Song;
    private AudioSource audio;
    public Obtainable ob;

	// Use this for initialization
	void Start () {
        AudioClip sound = (AudioClip)Resources.Load(Song, typeof(AudioClip));
        audio = GetComponent<AudioSource>();
        if (sound != null)
            audio.clip = sound;
        else
            Debug.Log("no");
        audio.Play();
    }
	
	// Update is called once per frame
	void Update () {
        if (ob != null) {
            if (ob.playingMusic == true) {
                audio.Stop();
            }
        }
	}
}
