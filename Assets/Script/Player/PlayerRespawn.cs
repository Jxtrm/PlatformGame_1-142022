using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour
{
    public Animator animator;
    public GameObject[] hearts;

    private float checkPointPositionX, checkPointPositionY;
    private int life;


    void Start()
    {
        life = hearts.Length;

        if (PlayerPrefs.GetFloat("checkPointPositionX") !=0)
        {
            transform.position = (new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY")));
        }
    }

    private void CheckLife()
    {
        if (life < 1)
        {
            hearts[0].SetActive(false);
            animator.Play("Hit");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (life < 2)
        {
            hearts[1].SetActive(false);
            animator.Play("Hit");
        }
        else if (life < 3)
        {
            hearts[2].SetActive(false);
            animator.Play("Hit");
        }
    }

    public void ReachedCheckPoint(float x, float y)
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
    }

    public void PlayerDamage()
    {
        life--;
        CheckLife();
    }
}
