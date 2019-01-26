using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obtainable : MonoBehaviour {

    public string scene;
    public PlayerController player;
    public bool isInside;
    public Fader fade;
    SpriteRenderer sr;
    //Animator anim;
	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
	}

    void Update()
    {
        if (isInside && player.interacts)
        {
            sr.enabled = false;
            StartCoroutine(LoadScene(scene));
            fade.SceneFinished = true;
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
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(scene);
    }
}
