using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorSpawner : MonoBehaviour {

    float waitValue;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        waitValue = Random.Range(2f, 3f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Vector3 newPos = transform.position;
            yield return new WaitForSeconds(waitValue);
            GameObject subGameObject = Instantiate(Resources.Load("meteor", typeof(GameObject)), newPos, Quaternion.identity) as GameObject;
        }
    }
}
