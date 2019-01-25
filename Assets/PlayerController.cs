using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public bool CanJump = true;
    public bool interacts = false;
    public float speed;
    public float jumpForce;
    Rigidbody2D rb;
    public bool isGrounded;
    public LayerMask whatIsGround;
    public float checkRadius;
    public Transform groundCheck;
    float moveInput;
    bool facingRight = true;
    Animator anim;
    public bool canMove = true;
    public Fader fade;

    // Use this for initialization
    void Start() {
        fade = GameObject.Find("Fade").GetComponent<Fader>();
        rb = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if (canMove) {
            moveInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(moveInput * speed, rb.position.y);
            if (facingRight && moveInput < 0)
                Flip();
            else if (facingRight == false && moveInput > 0)
                Flip();
        }else
        {
            rb.velocity = new Vector2();
        }
        
    }

    // Update is called once per frame
    void Update() {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded && CanJump)
        {
            //Debug.Log("Jump");
            //rb.velocity += Vector2.up * jumpForce;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            interacts = false;
        }
        interacts = false;
        if (Input.GetKeyDown(KeyCode.E))
            interacts = true;
	}

    void Flip() {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") {
            Debug.Log("dead");
            StartCoroutine(Die());
        }
    }
    IEnumerator Die() {
        canMove = false;
        //anim.SetTrigger("Die");
        fade.SceneFinished = true;
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
