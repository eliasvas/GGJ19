using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteorite : MonoBehaviour {

    public float fallSpeed = 30.0f;
    public float spinSpeed = 250.0f;
    float xPos;
    bool moving = true;
    float yPos;
    CircleCollider2D circle;
    Animator anim;

    private void Start()
    {
        circle = GetComponent<CircleCollider2D>();
        xPos = Random.Range(-2.5f, -3.5f);
        yPos = Random.Range(-2.5f, -3f);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (moving)
            transform.Translate(new Vector3(xPos,yPos,0) * fallSpeed * Time.deltaTime, Space.World);
        //transform.Rotate(Vector3.right, spinSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            CircleCollider2D c = GetComponent<CircleCollider2D>();
            c.enabled = false;
            if (gameObject != null)
            {
                StartCoroutine(StopMove());
                StartCoroutine(Explode());
            }
        }
        if (collision.name == "Player" || collision.tag == "ground") {
            StartCoroutine(StopMove());
            StartCoroutine(Explode());
        }
        
    }
    IEnumerator Explode() {
        circle.enabled = false;
        anim.SetTrigger("Explode");
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    IEnumerator StopMove() {
        yield return new WaitForSeconds(0.1f);
        moving = false;
    }
}
