using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {


    SpriteRenderer sr;
    public PlayerController player;
    public bool isInside;
    Animator anim;
    public Door door;
    public SpriteRenderer arrow;
    public Image painting;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
        painting = GameObject.Find("painting").GetComponent<Image>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if (isInside && player.interacts) {
            StartCoroutine(ShowPaintingStopPlayer());
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
    IEnumerator ShowPaintingStopPlayer() {
        //play some sound
        yield return new WaitForSeconds(0.5f);
        player.canMove = false;
        float opaq = 0f;
        while (painting.color.a < 1)
        {
            painting.color = new Color(painting.color.r, painting.color.g, painting.color.b, opaq);
            yield return new WaitForSeconds(0.10f);
            opaq += 0.05f;
        }
        painting.color = new Color(painting.color.r, painting.color.g, painting.color.b, 1);
        Debug.Log("alright");
        yield return new WaitForSeconds(3f);
        while (painting.color.a >0)
        {
            painting.color = new Color(painting.color.r, painting.color.g, painting.color.b, opaq);
            yield return new WaitForSeconds(0.10f);
            opaq -= 0.05f;
        }
        player.canMove = true;
    }
}
