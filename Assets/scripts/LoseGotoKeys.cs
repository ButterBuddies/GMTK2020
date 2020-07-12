using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseGotoKeys : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene("The Main scene");
        else if (Input.GetKeyDown(KeyCode.M))
            SceneManager.LoadScene("MainMenu");

    }
}
