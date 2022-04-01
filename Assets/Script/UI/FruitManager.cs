using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelClear;
    public GameObject transition;
    public Text fruitsCollected;
    public Text totalFruits;

    private int totalFruitsLevel;

    private void Start()
    {
        totalFruitsLevel = transform.childCount;
    }
    private void Update()
    {
        AllFruitsCollected();
        totalFruits.text = totalFruitsLevel.ToString();
        fruitsCollected.text = transform.childCount.ToString();
    }
    public void AllFruitsCollected()
    {
        if (transform.childCount==0)
        {
            Debug.Log("No frutas");
            levelClear.gameObject.SetActive(true);
            transition.SetActive(true);
            Invoke("NextLevel", 2);
        }
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
