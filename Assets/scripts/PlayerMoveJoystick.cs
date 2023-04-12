using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    public Joystick joystick;
    public float runSpeedHorizontal = 2;
    public float speed = 1.25f;
    public float jumbspeed = 3;
    public float doubleJumpspees = 2.5f;
    private bool canDoubleJump;
    Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;

    public Animator animator;
    bool isTouchingFont = false;
    bool wallSliding;
    public float wallSlidingSpeed = 0.75f;
    bool isTouchingDerecha;
    bool isTouchingIzquierda;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (horizontalMove>0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("Run", true);
        }
        else if (horizontalMove<0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        if (Checkground.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
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
        }
        else if (rb.velocity.y > 0)
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
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * speed;
    }
    public void Jump()
    {
        if (Checkground.isGrounded)
        {
            canDoubleJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumbspeed);
        }
        else
        {
            if (canDoubleJump)
            {
                animator.SetBool("DoubleJump", true);
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpspees);
                canDoubleJump = false;
            }
        }
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
