using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

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

    // Use this for initialization
    void Start() {
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
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && isGrounded) {
            //Debug.Log("Jump");
            //rb.velocity = Vector2.up * jumpForce;
            rb.AddForce(Vector2.up * jumpForce);
        }
	}

    void Flip() {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
