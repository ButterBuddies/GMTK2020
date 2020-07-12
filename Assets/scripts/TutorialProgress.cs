using UnityEngine.Playables;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialProgress : MonoBehaviour
{
    PlayerController controller;
   [SerializeField] PlayableDirector director;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ChangeScene();
        }
        if (controller.progress > 2)
        {
            if (director.state != PlayState.Playing)
                director.Play();
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("The Main scene");
    }
}
