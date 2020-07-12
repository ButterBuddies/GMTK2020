﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManger : MonoBehaviour
{
    public int loseRatCount;
    //public int winRatCount;
    public GameObject losePanel;
    //public GameObject ratSpawner;
    //public GameObject spawnerManager;

    //Use a slider to indicate the rat infestation and determine if we win or lost the game.
    // 0 means no rat infestaton
    // 100 or 1 means 100% rat infestation and you lose the game.
    // what about rat king? Hmm good fucking question!
    // Let's add a slider for his abominable health!
    public Slider RatInfestationStatus;
    public Slider RatKingHealth;
    public Image RatInfestationBackground;
    public Gradient colorRamp = new Gradient();

    public void Start()
    {
        InvokeRepeating("CountRats", 5, 5);
    }

    public void CountRats()
    {
        int ratCount = FindObjectsOfType<Rat>().Length;
        Debug.Log("Rat count: " + ratCount);

        //if (spawnerManager == null) //assuming the rat king has been defeated, the player won the game
        //{
        //    Debug.Log("rat king defeated");
        //    //SceneManager.LoadScene("Win");
        //}
        //else if (ratCount <= minRatCount && !ratKing.activeInHierarchy)
        //{
        //    Debug.Log("You won, rat infestation under control");
        //    StartBossFight();
        //    //SceneManager.LoadScene("Win");
        //}
        if(RatInfestationStatus != null )
        {
            // rip 24 bit of memory allocation for this... but aat least it's easy to read..
            float percentage = (ratCount / loseRatCount);
            float minVal = RatInfestationStatus.minValue;
            float maxVal = RatInfestationStatus.maxValue;
            RatInfestationStatus.value = (minVal - maxVal) * percentage + (minVal);
            if( RatInfestationBackground != null )
                RatInfestationBackground.color = colorRamp.Evaluate(percentage);
        }

        if (ratCount >= loseRatCount)
        {
            Debug.Log("You lose, rate infestation out of control!");
            Cursor.visible = true;
            losePanel.SetActive(true);
            //ratSpawner.SetActive(true);
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

    //public void StartBossFight()
    //{
    //    ratKing.SetActive(true);

    //}
}
