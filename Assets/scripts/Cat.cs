using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public enum Behavior { Flee, Chase, Idle, Freeze }
    //public enum Emotion { Lonely, Scared, Happy, Clean, Scout, Sleep, Eating}

    // in this case we can determine the shape and size of a cat object.
    public float speed = 5f;
    // if the cat weights gets too much, then thespeed of the cat and the emotion of the cat gets inflicted. 
    public float weight = 1f;
    // Hmm.... over the time if the cat consume too much then the weight becomes a factor
    [Range(0,1)]
    public float foodConsumption = 0.5f;
    // if the cat is losing weight then the speed and performance of the cat gets afected. affects tolerance and attention span?

    public Behavior CurrentBehavior = Behavior.Idle;
    public float AttentionSpan = 10f;

    [Range(0, 1)]
    public float tolerance = 0.5f;

    // in case the cat have found a target to aim for.
    private GameObject _suspectedTarget;

    #region Implementations
    public void MoveTowards( GameObject obj )
    {
        // in case of a laser pointer or some kind of target to
        CurrentBehavior = Behavior.Chase;
        _suspectedTarget = obj;
    }

    public void FleeFrom( GameObject obj )
    {
        CurrentBehavior = Behavior.Flee;
        _suspectedTarget = obj;
    }

    public void Feed(Food food)
    {
        // feed a cat based on the items?
        foodConsumption += food.ConsumeRate;
        foodConsumption = Mathf.Clamp01(foodConsumption);
        CurrentBehavior = Behavior.Idle;
    }

    /// <summary>
    /// In case when another cat identifies an object that might be particular interesting. 
    /// </summary>
    /// <param name="obj"></param>
    public void Provoke(GameObject obj )
    {
        // invoke the cat somehow? and how does the cat behaves to this reaction.
        // this will be a chances to either fight or flee...
        float t = Random.Range(0, 3);
        
        // could be Chase, Flee, or Idle (Frozen)...
        switch( Mathf.Round(t))
        {
            case 0: MoveTowards(obj); break;                    // we can chase the object? Why not!
            case 1: CurrentBehavior = Behavior.Freeze; break;   // cat scared, can't move?
            case 2: FleeFrom(obj); break;                       // Cat afraid, flee from object.
            default:
                {
                    // hmm we broke here?
                    CurrentBehavior = Behavior.Freeze;
                    Debug.Log("This should not happen... But whatever!");
                    break;
                }
        }
    }

    #endregion

    #region Behavior engine

    // Update is called once per frame
    void FixedUpdate()
    {
        switch(CurrentBehavior)
        {
            case Behavior.Chase: break;
            case Behavior.Flee: break;
            case Behavior.Freeze: break;
            case Behavior.Idle: break;
            default: // hmm you did something wrong to make this happen shame on you and yoru code design... 
                break;
        }
    }
    


    #endregion
}
