using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour {

    Rigidbody2D rb;
    BoxCollider2D box;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Fall());
        box = GetComponent<BoxCollider2D>();
        box.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Fall() {
        yield return new WaitForSeconds(2f);
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
