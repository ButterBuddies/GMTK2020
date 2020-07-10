using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : Item
{
    public float AttentionRadius = 10.0f;
    [Range(0,1)]
    public float BatteryLife = 1.0f;    //???? do we want this to be implemented????
    public float BatteryConsumption = 0.01f;     // how much of battery life do we need to drain over the time?
    // this is to indicate how many cats needs to focus on Laser pointer when its' turned on.
    public List<Cat> Cats;

    // Hmmm..... interesting?
    public bool isOn = false;
}
