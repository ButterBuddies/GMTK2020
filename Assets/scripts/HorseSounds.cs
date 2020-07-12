using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Audio;

public class HorseSounds : MonoBehaviour
{
    CharacterController controller;
    AudioSource source;
    [SerializeField] AudioClip wingflap;
    [SerializeField] AudioClip clipclop;

    AudioClip soundToPlay;

    public bool flying = true;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();
        if (flying)
        {
            soundToPlay = wingflap;
        }
        else
        {
            soundToPlay = clipclop;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.velocity != Vector3.zero)
        {
            if (!source.isPlaying) 
            {
                Debug.Log("SFX");
                source.clip = soundToPlay;
                source.Play();
            }
        }
        else
        {
            source.Stop();
        }
    }
}
