using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {

    AudioSource audio;
    Animator anim;
    public bool isOnDoor;
    public string scene;
    public bool CanOpen = false;
    PlayerController player;
    Animator playerAnimator;
    SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        AudioClip sound = (AudioClip)Resources.Load("doorsound", typeof(AudioClip));
        audio = GetComponent<AudioSource>();
        if (sound != null)
            audio.clip = sound;
        else
            Debug.Log("no");
        sr = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        anim = GetComponent<Animator>();
        //an CanOpen == false to allakse to sprite sto kanoniko
	}
	
	// Update is called once per frame
	void Update () {
        if (!CanOpen)
            sr.color = new Color(0f, 255f, 255f, 1f); // Set to opaque black
        else
            sr.color = new Color(255f, 255f, 255f, 1f);
        if (isOnDoor && Input.GetKeyDown(KeyCode.E) && CanOpen) {
            player.OpenDoor();
            anim.SetTrigger("open");
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
        audio.Play();
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(scene);
    }
}
