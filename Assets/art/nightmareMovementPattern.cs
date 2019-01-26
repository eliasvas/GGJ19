using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nightmareMovementPattern : MonoBehaviour {
    AudioSource sound;
    public bool isDestructable = true;
    SpriteRenderer sr;
    public float MoveSpeed = 5.0f;
    Transform player;
    
    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 0.5f;   // Size of sine movement
    private Vector3 axis;
    public Animator anim;

    private Vector3 pos;
    float randomSpawnDegrees = 0;
    public bool tim;
    GameObject playerGameObject;
    

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        playerGameObject = GameObject.Find("Player");

        GameObject pla = GameObject.Find("Player");
        PlayerController pl = pla.GetComponent<PlayerController>();

        anim = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player").transform;
        randomSpawnDegrees = Random.Range(0, 360);
        pos = transform.position;
        //DestroyObject(gameObject, 1.0f);
        axis = transform.up;  // May or may not be the axis you want
        transform.Rotate(0, 0, randomSpawnDegrees, Space.Self);
        //StartCoroutine(destroy());
        
    }

    void Update()
    {
        if (gameObject != null)
        {
            pos += (-1) * transform.right * Time.deltaTime * MoveSpeed;
            transform.position = pos + axis * Mathf.Cos(Time.time * frequency) * magnitude + new Vector3(0, 0, randomSpawnDegrees);

            //TESTETESTTETSTTESTETSTETSTEST
            //What is the difference in position?
            Vector3 diff = (player.position - transform.position);

            //We use aTan2 since it handles negative numbers and division by zero errors. 
            float angle = Mathf.Atan2(diff.y, diff.x);

            //Now we set our new rotation. 
            transform.rotation = Quaternion.Euler(0f, 0f,angle * Mathf.Rad2Deg + 180 * Mathf.Rad2Deg);

        }
        //IF BACKGROUNG == BLACKONE THEN DISABLE RENDERER AND COLLIDER YEHA 
    }


    IEnumerator destroy() {
        Debug.Log("Destroy");
        if (isDestructable) {
            yield return new WaitForSeconds(7.0f);
            if (gameObject != null) Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Respawn") {
            sr.enabled = false;
            BoxCollider2D c = GetComponent<BoxCollider2D>();
            c.enabled = false;
            if (gameObject != null) {
                isDestructable = false;
                StartCoroutine(animateDeath());
                //Destroy(gameObject);
            }
            StartCoroutine(WaitAndGiveColliderBack(c));
        }
        if (other.name == "Player") {
            BoxCollider2D c = GetComponent<BoxCollider2D>();
            //c.enabled = false;
            GameObject p = GameObject.Find("Player");
            PlayerController pm = p.GetComponent<PlayerController>();
            //StartCoroutine(WaitSoundDie(c));
        }
        
    }

    IEnumerator WaitAndGiveColliderBack(BoxCollider2D c) {
        yield return new WaitForSeconds(0.5f);
        DiagnoseWithDead();
    }

    IEnumerator WaitSoundDie(BoxCollider2D c) {
        //sound.Play();
        //yield return new WaitForSeconds(0.5f);
        DiagnoseWithDead();
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator animateDeath() {
        //anim.SetBool("isDead", true);
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
    void DiagnoseWithDead() {
        StartCoroutine(animateDeath());
    }
}
