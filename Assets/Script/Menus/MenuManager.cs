using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject fruitsCount; 
    public GameObject heartsCount;
    public AudioSource clip;

    public void PlaySoundButton()
    {
        clip.Play();
    }
    public void PauseMenu()
    {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
        fruitsCount.SetActive(false);
        heartsCount.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
        fruitsCount.SetActive(true);
        heartsCount.SetActive(true);
    }

    public void Options()
    {
        Debug.Log("ENTRANDO A OPCIONES...");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("LevelSelectorMenu");
        Time.timeScale = 1;
        fruitsCount.SetActive(true);
        heartsCount.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("SALIENDO...");
    }

}
