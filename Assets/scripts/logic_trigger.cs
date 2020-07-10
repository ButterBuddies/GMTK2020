using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class logic_trigger : MonoBehaviour
{
    public UnityEvent CollisionEnter;
    public UnityEvent CollisionExit;
    public UnityEvent CollisionStay;

    public UnityEvent TriggerEnter;
    public UnityEvent TriggerExit;
    public UnityEvent TriggerStay;

    // maybe we need to fire once?

    public void Awake()
    {
        if( GetComponent<Collider>() is null && GetComponent<Collider2D>() is null )
        {
            Debug.LogError($"No collider found on this gameObject {this.gameObject.name}! Disabling");
            this.enabled = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        CollisionEnter.Invoke();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionEnter.Invoke();
    }

    public void OnCollisionExit(Collision collision)
    {
        CollisionExit.Invoke();
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        CollisionExit.Invoke();
    }

    public void OnCollisionStay(Collision collision)
    {
        CollisionStay.Invoke();
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        CollisionStay.Invoke();
    }

    public void OnTriggerEnter(Collider other)
    {
        TriggerEnter.Invoke();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        TriggerEnter.Invoke();
    }

    public void OnTriggerExit(Collider other)
    {
        TriggerExit.Invoke();
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        TriggerExit.Invoke();
    }

    public void OnTriggerStay(Collider other)
    {
        TriggerStay.Invoke();
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        TriggerStay.Invoke();
    }
}
