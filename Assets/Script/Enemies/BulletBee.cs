using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBee : MonoBehaviour
{
    public float speedBullet = 2f;
    public float lifeTimeBullet = 2f;

    private void Start()
    {
        Destroy(gameObject, lifeTimeBullet);
    }

    private void Update()
    {
        transform.Translate(Vector2.down * speedBullet * Time.deltaTime);
    }
}
