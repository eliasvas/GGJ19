using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steam : MonoBehaviour {

    BoxCollider2D box;

	// Use this for initialization
	void Start () {
        box = GetComponent<BoxCollider2D>();
        box.enabled = false;
        StartCoroutine(Damage());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator Damage() {
        while (true) {
            yield return new WaitForSeconds(1.4f);
            box.enabled = true;
            yield return new WaitForSeconds(0.8f);
            box.enabled = false;
        }
    }
}
