using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {


    SpriteRenderer sr;
    public PlayerController player;
    public bool isInside;
    Animator anim;
    public Door door;
    public SpriteRenderer arrow;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (isInside && player.interacts) {
            sr.enabled = true;
            arrow.enabled = false;
            door.CanOpen = true;
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
