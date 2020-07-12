using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class HorseSounds : MonoBehaviour
{
    CharacterController controller;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.velocity != Vector3.zero)
        {
            if (!source.isPlaying) 
            {
                source.Play();
            }
        }
        else
        {
            source.Stop();
        }
    }
}
