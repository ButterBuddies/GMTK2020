using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{
    public int maxRatCount;
    public int minRatCount;
    public GameObject losePanel;
    public GameObject ratSpawner;

    public void Start()
    {
        InvokeRepeating("CountRats", 5, 5);
    }

    public void CountRats()
    {

        int ratCount = FindObjectsOfType<Rat>().Length;
        Debug.Log("Rat count: " + ratCount);

        if (ratCount <= minRatCount)
        {
            Debug.Log("You won, rat infestation under control");

        }
        else if (ratCount >= maxRatCount)
        {
            Debug.Log("You lose, rate infestation out of control");
            Cursor.visible = true;
            losePanel.SetActive(true);
            ratSpawner.SetActive(true);
        }
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
