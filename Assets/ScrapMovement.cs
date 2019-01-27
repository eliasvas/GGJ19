using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrapMovement : MonoBehaviour {

    Vector3 reversePos = new Vector3(200, 0, 0);

    public float fallSpeed = 30.0f;
    Vector3 movement = new Vector3(-3.5f, -1.5f, 0) ;
    public float spinSpeed = 250.0f;
    float xPos;
    SpriteRenderer sr;
    bool moving = true;
    float yPos;
    BoxCollider2D circle;
    Animator anim;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        movement *= fallSpeed;
    }

    void Update()
    {
        if (moving)
            transform.Translate(movement*Time.deltaTime, Space.World);
        //transform.Rotate(Vector3.right, spinSpeed * Time.deltaTime);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Respawn")
        {
            CircleCollider2D c = GetComponent<CircleCollider2D>();
            //c.enabled = false;
            if (gameObject != null)
            {
                movement = reversePos;
            }
        }
        if (collision.name == "Player" || collision.tag == "ground")
        {
            StartCoroutine(StopMove());
            StartCoroutine(Explode());
        }

    }
    IEnumerator Explode()
    {
        circle.enabled = false;
        float op = 1f;
        while (sr.color.a > 0)
        {
            sr.color = new Color(255f, 255f, 255f, op);
            yield return new WaitForSeconds(0.1f);
            op -= 0.2f;
        }
        Destroy(gameObject);
    }
    IEnumerator StopMove()
    {
        yield return new WaitForSeconds(0.1f);
        moving = false;
    }
}
