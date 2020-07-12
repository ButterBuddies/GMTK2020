using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCallingScript : MonoBehaviour
{
    [SerializeField] float minTime = 10f;
    [SerializeField] float maxTime = 120f;

    public AudioClip[] hungrySounds;
    public AudioClip[] normalSounds;
    public AudioClip[] scaredSounds;

    Cat catScript;
    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        catScript = GetComponent<Cat>();
        source = GetComponent<AudioSource>();
        StartCoroutine(Call());
    }

    IEnumerator Call()
    {
        yield return new WaitForSeconds(Random.Range(10f, 120f));
        switch (catScript.CurrentBehavior)
        {
            case Cat.Behavior.Chase: source.PlayOneShot(hungrySounds[Random.Range(0, hungrySounds.Length)]);
                break;
            case Cat.Behavior.Flee: source.PlayOneShot(scaredSounds[Random.Range(0, scaredSounds.Length)]);
                break;
            case Cat.Behavior.Idle: source.PlayOneShot(normalSounds[Random.Range(0, normalSounds.Length)]);
                break;
        }
        StartCoroutine(Call());
    }
}
