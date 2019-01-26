using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public int xMin = 10;
    public int xMax = 20;
    public int yMin = 0;
    public int yMax = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void SpawnEnemy()
    {
        Vector3 newPos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
        GameObject subGameObject = Instantiate(Resources.Load("drop", typeof(GameObject))) as GameObject;
    }
}
