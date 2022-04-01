using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlant : MonoBehaviour
{
    public float speedBullet = 2f;
    public float lifeTimeBullet = 2f;
    public bool left;

    private void Start()
    {
        Destroy(gameObject, lifeTimeBullet);
    }

    private void Update()
    {
        if (left)
        {
            transform.Translate(Vector2.left * speedBullet * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speedBullet * Time.deltaTime);
        }
    }
}
