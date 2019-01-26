using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour {

    AudioSource audio;
    Rigidbody2D rb;
    BoxCollider2D box;

	// Use this for initialization
	void Start () {
        AudioClip sound = (AudioClip)Resources.Load("watersound", typeof(AudioClip));
        audio = GetComponent<AudioSource>();
        if (sound != null)
            audio.clip = sound;
        else
            Debug.Log("no");
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Fall());
        box = GetComponent<BoxCollider2D>();
        box.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Fall() {
        yield return new WaitForSeconds(1f);
        audio.Play();
        yield return new WaitForSeconds(0.3f);
        box.enabled = true;
        rb.gravityScale = 70;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ground") {
            //Debug.Log("destroyed");
            Destroy(gameObject);
        }
    }
}
