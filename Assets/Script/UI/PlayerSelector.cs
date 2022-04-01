using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelector : MonoBehaviour
{
    public enum Player {Frog, MaskGuy};
    public Player playerSelected;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public bool enableSelectPlayer;
    public RuntimeAnimatorController[] playerController;
    public Sprite[] playerRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (!enableSelectPlayer)
        {
            ChangePlayerInMenu();
        }
        else
        {
            switch (playerSelected)
            {
                case Player.Frog:
                    spriteRenderer.sprite = playerRenderer[0];
                    animator.runtimeAnimatorController = playerController[0];
                    break;
                case Player.MaskGuy:
                    spriteRenderer.sprite = playerRenderer[1];
                    animator.runtimeAnimatorController = playerController[1];
                    break;
                default:
                    break;
            }
        }
    }

    public void ChangePlayerInMenu()
    {
        switch (PlayerPrefs.GetString("PlayerSelected"))
        {
            case "Frog":
                spriteRenderer.sprite = playerRenderer[0];
                animator.runtimeAnimatorController = playerController[0];
                break;
            case "MaskGuy":
                spriteRenderer.sprite = playerRenderer[1];
                animator.runtimeAnimatorController = playerController[1];
                break;
            default:
                break;
        }
    }
}
