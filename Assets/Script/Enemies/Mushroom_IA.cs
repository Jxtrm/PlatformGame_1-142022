using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_IA : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float speed = 0.5f;
    public float startWaitTime = 2f;
    public Transform[] moveSpots;

    private float waitTime;
    private int i = 0;
    private Vector2 actualPosition;

    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(CheckEnemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[i].transform.position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[i].transform.position) <0.1f)
        {
            if (waitTime <= 0)
            {
                if (moveSpots[i] != moveSpots[moveSpots.Length -1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator CheckEnemyMoving()
    {
        actualPosition = transform.position;
        yield return new WaitForSeconds(0.5f);

        if (transform.position.x > actualPosition.x)
        {
            spriteRenderer.flipX = true;
            animator.SetBool("itsIdle", false);
        }
        else if (transform.position.x < actualPosition.x)
        {
            spriteRenderer.flipX = false;
            animator.SetBool("itsIdle", false);
        }
        else if (transform.position.x==actualPosition.x)
        {
            animator.SetBool("itsIdle", true);
        }
    }
}
