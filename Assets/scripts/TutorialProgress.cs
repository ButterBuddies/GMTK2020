using UnityEngine.Playables;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialProgress : MonoBehaviour
{
    PlayerController controller;
    [SerializeField] PlayableAsset cutscene;
   [SerializeField] PlayableDirector director;
    bool playing =false;

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
            if (!playing)
            {
                Debug.Log("playing");
                director.Play(cutscene);
                playing = true;
            }
        }
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("The Main scene");
    }
}
