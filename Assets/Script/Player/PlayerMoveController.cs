using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    public float runSpeed = 1.25f;
    public float runSpeedHorizontal = 2f;
    public float jumpSpeed = 3f;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public float doubleJumpSpeed = 2.5f;
    public Joystick joystick;
    public GameObject dustRight;
    public GameObject dustLeft;

    private bool canDoubleJump;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (horizontalMove>0)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("itsRun", true);
            dustLeft.SetActive(true);
            dustRight.SetActive(false);
        }
        else if (horizontalMove<0)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("itsRun", true);
            dustRight.SetActive(true);
            dustLeft.SetActive(false);
        }
        else
        {
            animator.SetBool("itsRun", false);
            dustLeft.SetActive(false);
            dustRight.SetActive(false);
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("itsJump", true);
            animator.SetBool("itsRun", false);
            dustRight.SetActive(false);
            dustLeft.SetActive(false);
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
    }

    void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;
    }

    public void Jump()
    {
        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        else
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
