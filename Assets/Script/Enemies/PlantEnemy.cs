using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantEnemy : MonoBehaviour
{
    public float waitedTimeToAttack = 3f;
    public Animator animator;
    public GameObject bullet;
    public Transform launchSpawnPoint;
    private float waitedTime;

    private void Start()
    {
        waitedTime = waitedTimeToAttack;
    }

    private void Update()
    {
        if (waitedTime <= 0)
        {
            waitedTime = waitedTimeToAttack;
            animator.Play("Attack");
            Invoke("LaunchBullet", 0.5f);
        }
        else
        {
            waitedTime -= Time.deltaTime;
        }
    }

    public void LaunchBullet()
    {
        GameObject newBullet;
        newBullet = Instantiate(bullet, launchSpawnPoint.position, launchSpawnPoint.rotation);
    }
}
