using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 2;
    public float jumbspeed = 3;
    public float doubleJumpspees = 2.5f;
    private bool canDoubleJump;
    Rigidbody2D rb;

    public bool betterJump = false;

    public float fallMutipiler = 0.5f;

    public float lowJumpMutiplayer = 1f;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    public GameObject dustLeft;
    public GameObject dustRight;

    public float dashCooldown;
    public float dashFore = 30;
    public GameObject dashParticale;

    bool isTouchingFont = false;
    bool wallSliding;
    public float wallSlidingSpeed = 0.25f;
    bool isTouchingDerecha;
    bool isTouchingIzquierda;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        dashCooldown -= Time.deltaTime;
        if (Input.GetKey("space") && wallSliding == false)
        {
            if (Checkground.isGrounded)
            {
                canDoubleJump = true;
                rb.velocity = new Vector2(rb.velocity.x, jumbspeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("DoubleJump", true);
                        rb.velocity = new Vector2(rb.velocity.x, doubleJumpspees);
                        canDoubleJump = false;
                    }
                }
            }

        }
        if (Checkground.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }
        if (Checkground.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);
        }
        if (rb.velocity.y < 0)
        {
            animator.SetBool("Falling", true);
        } else if (rb.velocity.y > 0)
        {
            animator.SetBool("Falling", false);
        }
        if (isTouchingFont == true && Checkground.isGrounded == false)
        {
            wallSliding = true;
        }
        else
        {
            wallSliding = false;
        }
        if (wallSliding)
        {
            animator.Play("WallJump");
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
    }
    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right") && isTouchingDerecha == false)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
            if(Checkground.isGrounded == true)
            {
                dustLeft.SetActive(true);
                dustRight.SetActive(false);
            }
        }else if (Input.GetKey("e") && dashCooldown<=0)
        {
            Dash();
        }
        else if (Input.GetKey("a") || Input.GetKey("left") && isTouchingIzquierda == false)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
            if (Checkground.isGrounded == true)
            {
                dustLeft.SetActive(false);
                dustRight.SetActive(true);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("Run", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }
        
        if (betterJump)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMutipiler) * Time.deltaTime;
            }
            if (rb.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMutiplayer) * Time.deltaTime;
            }
        }
    }
    public void Dash()
    {
        GameObject dashObject;
        dashObject = Instantiate(dashParticale,transform.position,transform.rotation);
        if(spriteRenderer.flipX == true)
        {
            rb.AddForce(Vector2.left * dashFore,ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForce(Vector2.right * dashFore, ForceMode2D.Impulse);
        }
        dashCooldown = 2;
        Destroy(dashObject,1);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ParedDerecha"))
        {
            isTouchingFont = true;
            isTouchingDerecha = true;
        }
        if (collision.gameObject.CompareTag("Paredzquierda"))
        {
            isTouchingFont = true;
            isTouchingDerecha = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isTouchingFont = false;
        isTouchingDerecha = false;
        isTouchingIzquierda = false;
    }
    
}
