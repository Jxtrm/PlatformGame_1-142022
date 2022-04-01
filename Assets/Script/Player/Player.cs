using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    public bool betterJump = false;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public float doubleJumpSpeed = 2.5f;
    public GameObject dustRight;
    public GameObject dustLeft;
    public float wallSlideSpeed = 0.75f;

    private bool canDoubleJump;
    private bool itsTouchingFront= false;
    private bool wallSlide = false;
    private bool itsTouchRight = false;
    private bool itsTouchingLeft = false;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey("space") || Input.GetKey("up") && wallSlide == false)
        {
            if (CheckGround.isGrounded)
            {
                canDoubleJump = true;
                rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            }
            else
            {
                if (Input.GetKeyDown("space"))
                {
                    if (canDoubleJump)
                    {
                        animator.SetBool("itsDoubleJump", true);
                        rb.velocity = new Vector2(rb.velocity.x, doubleJumpSpeed);
                        canDoubleJump = false;
                    }
                }
            }
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("itsJump", true);
            animator.SetBool("itsRun", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }

        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("itsJump", false);
            animator.SetBool("itsDoubleJump", false);
            animator.SetBool("itsFall", false);
        }

        if (rb.velocity.y < 0)
        {
            animator.SetBool("itsFall", true);
        }
        else if (rb.velocity.y > 0)
        {
            animator.SetBool("itsFall", false);
        }

        if (itsTouchingFront == true && CheckGround.isGrounded == false)
        {
            wallSlide = true;
        }
        else
        {
            wallSlide = false;
        }

        if (wallSlide)
        {
            animator.Play("WallSlide");
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlideSpeed, float.MaxValue));
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey("d") || Input.GetKey("right") && itsTouchRight == false)
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            spriteRenderer.flipX = false;
            animator.SetBool("itsRun", true);
            if (CheckGround.isGrounded==true)
            {
                dustLeft.SetActive(true);
                dustRight.SetActive(false);
            }
        }
        else if (Input.GetKey("a") || Input.GetKey("left") && itsTouchingLeft == false)
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
            spriteRenderer.flipX = true;
            animator.SetBool("itsRun", true);
            if (CheckGround.isGrounded == true)
            {
                dustLeft.SetActive(false);
                dustRight.SetActive(true);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("itsRun", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }

        if (betterJump)
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rb.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ParedDch"))
        {
            itsTouchingFront = true;
            itsTouchRight = true;
        }

        if (collision.gameObject.CompareTag("ParedIzq"))
        {
            itsTouchingFront = true;
            itsTouchingLeft = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        itsTouchingFront = false;
        itsTouchingLeft = false;
        itsTouchRight = false;
    }
}
