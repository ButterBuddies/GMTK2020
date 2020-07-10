using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int buildIndex )
    {
        try
        {
            SceneManager.LoadScene(buildIndex);
        }
        catch
        {
            Debug.LogError("Did you forgot to add the scene to the build manager?");
        }
        
    }

    public void LoadScene(string SceneName)
    {
        try
        {
            SceneManager.LoadScene(SceneName);
        }
        catch
        {
            Debug.LogError("Did you misspell or did you check and see if the scene name exist in the build manager?");
        }
    }

    /// <summary>
    /// Loads the next scene in order of the build index.
    /// </summary>
    public void LoadNextScene()
    {
        try
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        catch
        {
            SceneManager.LoadScene(0);
        }
    }

    public void Quit()
    {
        //hmm do we need to worry about WebGL?
        Application.Quit();
    }
}
