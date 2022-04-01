using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinsDoor : MonoBehaviour
{
    public GameObject skinsPanel;
    public GameObject player;

    private bool inDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            skinsPanel.gameObject.SetActive(true);
            inDoor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        skinsPanel.gameObject.SetActive(false);
        inDoor = false;
    }

    public void SetPlayerFrog()
    {
        PlayerPrefs.SetString("PlayerSelected", "Frog");
        ResetPlayerSkin();
    }
    public void SetPlayerMaskGuy()
    {
        PlayerPrefs.SetString("PlayerSelected", "MaskGuy");
        ResetPlayerSkin();
    }

    void ResetPlayerSkin()
    {
        skinsPanel.gameObject.SetActive(false);
        player.GetComponent<PlayerSelector>().ChangePlayerInMenu();
    }
}
