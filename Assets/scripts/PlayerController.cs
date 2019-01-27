using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public bool invulnerable;
    bool isAlive = true;
    public bool CanJump = true;
    public bool interacts = false;
    public float speed;
    public float jumpForce;
    Rigidbody2D rb;
    public bool isGrounded;
    public LayerMask whatIsGround;
    public float checkRadius;
    bool canPlayMusic = true;
    public Transform groundCheck;
    float moveInput;
    bool facingRight = true;
    Animator anim;
    public bool canMove = true;
    public Fader fade;
    public BoxCollider2D melee;
    bool canAttack = true;
    float movement;
    public AudioSource audio;
    public SpriteRenderer attack;

    // Use this for initialization
    void Start() {
        AudioClip sound = (AudioClip)Resources.Load("ironhit", typeof(AudioClip));
        audio = GetComponent<AudioSource>();
        if (sound != null)
            audio.clip = sound;
        else
            Debug.Log("no");
        fade = GameObject.Find("Fade").GetComponent<Fader>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attack = GameObject.Find("meleeRange").GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (canMove) {
            moveInput = Input.GetAxis("Horizontal");
            anim.SetFloat("speed", Mathf.Abs(moveInput));
            rb.velocity = new Vector2(moveInput * speed , rb.velocity.y);
            if (facingRight && moveInput < 0)
                Flip();
            else if (facingRight == false && moveInput > 0)
                Flip();
        }else
        {
            rb.velocity = new Vector2();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded && CanJump)
        {
            //Debug.Log("Jump");
            rb.velocity = new Vector2(0, jumpForce);
            //rb.AddForce(Vector2.up * jumpForce );
            interacts = false;
        }
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Space) && canAttack)
            StartCoroutine(Fire());
        interacts = false;
        if (Input.GetKeyDown(KeyCode.E))
            interacts = true;
        if (Input.GetKeyDown(KeyCode.Tab))
            invulnerable = !invulnerable;
	}

    void Flip() {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && isAlive && !invulnerable) {
            isAlive = false;
            Debug.Log("dead");
            StartCoroutine(Die());
        }
    }
    IEnumerator Die() {
        rb.gravityScale = 300;
        canMove = false;
        anim.SetTrigger("die");
        AudioClip sound = (AudioClip)Resources.Load("diefix", typeof(AudioClip));
        audio = GetComponent<AudioSource>();
        if (sound != null)
            audio.clip = sound;
        else
            Debug.Log("no");
        audio.volume = 1;
        audio.Play();
        canPlayMusic = false;
        yield return new WaitForSeconds(2f);
        fade.SceneFinished = true;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OpenDoor() {
        canMove = false;
        //anim.SetTrigger("OpenDoor");
    }
    IEnumerator Fire() {
        if (canPlayMusic)
            audio.Play();
        anim.SetTrigger("hit");
        attack.enabled = true;
        canAttack = false;
        melee.enabled = true;
        yield return new WaitForSeconds(0.2f);
        melee.enabled = false;
        canAttack = true;
        attack.enabled = false;
    }
}
