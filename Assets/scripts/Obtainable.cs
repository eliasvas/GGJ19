using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obtainable : MonoBehaviour {

    public bool playingMusic;
    public string scene;
    public PlayerController player;
    public bool isInside;
    public Fader fade;
    SpriteRenderer sr;
    AudioSource audio;
    //Animator anim;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        //anim = GetComponent<Animator>();
        AudioClip sound = (AudioClip)Resources.Load("find", typeof(AudioClip));
        audio = GetComponent<AudioSource>();
        if (sound != null)
            audio.clip = sound;
        else
            Debug.Log("no");
    }

    void Update()
    {
        if (isInside && player.interacts)
        {
            playingMusic = true;
            sr.enabled = false;
            player.invulnerable = true;
            StartCoroutine(LoadScene(scene));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            isInside = false;
        }
    }
    IEnumerator LoadScene(string scene)
    {
        audio.Play();
        
        yield return new WaitForSeconds(3.0f);
        fade.SceneFinished = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
    }
}
