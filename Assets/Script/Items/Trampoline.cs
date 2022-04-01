using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    public Animator animator;
    public float jumpTFroce = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            animator.Play("Jump_Trampoline");
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpTFroce;
        }
    }

}
