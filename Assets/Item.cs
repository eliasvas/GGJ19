using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {


    SpriteRenderer sr;
    public PlayerController player;
    public bool isInside;
    Animator anim;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = true;
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (isInside && player.interacts) {
            sr.enabled = false; ;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player") {
            isInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player") {
            isInside = false;
        }
    }
}
