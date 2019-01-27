using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HobGoblin : MonoBehaviour {

    public int health = 3;
    PlayerController player;
    Rigidbody2D playerRigid;
    Animator anim;
    Transform playerTransform;
    SpriteRenderer sr;
    public Transform spawnPos;
    bool attacking = false;
    public CircleCollider2D force;
	// Use this for initialization
	void Start () {
        playerRigid = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        //playerRigid.AddForce(new Vector3(-1000000, 200000, 0));
        StartCoroutine(AttackPattern());
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Vector2.Distance(transform.position, playerTransform.position));
        if (!attacking && Vector2.Distance(transform.position, playerTransform.position) < 50)
        {
            attacking = true;
            StartCoroutine(Floor());
        }
        else if (!attacking && Vector2.Distance(transform.position, playerTransform.position) < 200)
        {
            attacking = true;
            StartCoroutine(AttackPattern());
        }
        if (health <= 0) {
            attacking = true;
            StartCoroutine(Explode());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            --health;
        }

    }

    IEnumerator Floor() {
        attacking = true;
        anim.SetTrigger("floor");
        force.enabled = true;
        yield return new WaitForSeconds(0.1f);
        force.enabled = false;
        //playerRigid.AddForce(new Vector3(-10000000, 200000, 0));
        attacking = false;
    }
    IEnumerator AttackPattern()
    {
        attacking = true;
        float rng = Random.Range(0, 3);
        if (rng == 1)
        {
            //throw
            if (anim != null)
                anim.SetTrigger("throw");
            Vector3 newPos = spawnPos.position;
            yield return new WaitForSeconds(0.35f);
            GameObject subGameObject = Instantiate(Resources.Load("scrap", typeof(GameObject)), newPos, Quaternion.identity) as GameObject;
            //Instantiate();
        }
        yield return new WaitForSeconds(1f);
        attacking = false;
    }
    IEnumerator Explode()
    {
        //circle.enabled = false;
        float op = 1f;
        while (sr.color.a > 0)
        {
            sr.color = new Color(255f, 255f, 255f, op);
            yield return new WaitForSeconds(0.1f);
            op -= 0.2f;
        }
        Destroy(gameObject);
    }
}
