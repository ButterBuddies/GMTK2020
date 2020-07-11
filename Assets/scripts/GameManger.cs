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
    public GameObject ratKing;


    public void Start()
    {
        InvokeRepeating("CountRats", 5, 5);
    }

    public void CountRats()
    {

        int ratCount = FindObjectsOfType<Rat>().Length;
        Debug.Log("Rat count: " + ratCount);

        if (ratKing == null) //assuming the rat king has been defeated, the player won the game
        {
            Debug.Log("rat king defeated");
            //SceneManager.LoadScene("Win");
        }
        else if (ratCount <= minRatCount && !ratKing.activeInHierarchy)
        {
            Debug.Log("You won, rat infestation under control");
            StartBossFight();
            //SceneManager.LoadScene("Win");
        }
        else if (ratCount >= maxRatCount && !ratKing.activeInHierarchy)
        {
            Debug.Log("You lose, rate infestation out of control");
            Cursor.visible = true;
            losePanel.SetActive(true);
            ratSpawner.SetActive(true);
        }
        //else if (ratKing.activeInHierarchy) 
        //{
        //    //need to check how many cats are left.... if too little or 0, we can assume the player lost the battle to the rat king
        //}

    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartBossFight()
    {
        ratKing.SetActive(true);

    }
}
