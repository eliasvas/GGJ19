using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEnemy());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator SpawnEnemy()
    {
        while (true) {
            Vector3 newPos = transform.position;
            yield return new WaitForSeconds(2f);
            GameObject subGameObject = Instantiate(Resources.Load("drop", typeof(GameObject)), newPos,Quaternion.identity) as GameObject;
        }
    }
}
