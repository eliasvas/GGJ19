using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour {

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Fall());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Fall() {
        yield return new WaitForSeconds(2f);
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
