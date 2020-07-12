using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : Item
{
    public float AttentionRadius = 10.0f;
    public float BatteryLife = 100f;
    public float usageDrain = 2f;
    public float rechargeRate = 1f;
    public float delayToRecharge = 1f;
    private float _t;
    public enum State { Using, Idle, Recharging, Dead }
    public State state = State.Idle;

    public GameObject Pointers;

    // Hmmm..... interesting?
    public bool isOn = false;

    // add

    public void Update()
    {
        isOn = Input.GetButton("Fire");
    }

    public void FixedUpdate()
    {
        if (state == State.Dead)
        {
            isOn = false;
        }

        if ( isOn )
        {
            
        }
        else
        {

        }
    }

}
