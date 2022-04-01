using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAttack : MonoBehaviour
{
    public Animator animator;
    public float distanceRaycast = 0.5f;
    public GameObject bullet;

    private float cooldownAttack = 1.5f;
    private float actualCooldownAttack;
    // Start is called before the first frame update
    void Start()
    {
        actualCooldownAttack = 0;
    }

    // Update is called once per frame
    void Update()
    {
        actualCooldownAttack -= Time.deltaTime;
        Debug.DrawRay(transform.position, Vector2.down * distanceRaycast, Color.red);
    }
    private void FixedUpdate()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, Vector2.down, distanceRaycast);

        if (hit2D.collider != null)
        {
            if (hit2D.collider.CompareTag("Player"))
            {
                if (actualCooldownAttack < 0)
                {
                    Invoke("LaunchBullet", 0.5f);
                    animator.Play("Attack");
                    actualCooldownAttack = cooldownAttack;
                }
            }
        }
    }

    void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bullet, transform.position, transform.rotation);
    }
}
