using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupAble : MonoBehaviour
{

    public Collider col;
    public Collider trigger;
    public Rigidbody rb;
    private PlayerController player;
    public Attention attention;
    public Threat threat;

    bool held;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log("pickup touched something: " + other.name);

        if (other.gameObject.tag == "Player")
        {   //If player touches this pickup, it gets added to their inventory
            if (!other.GetComponent<PlayerController>().HandsFull())
            {
                col.enabled = false;
                //rb.isKinematic = false;
                rb.constraints = RigidbodyConstraints.FreezeAll;
                transform.SetParent(other.GetComponent<PlayerController>().holdingPos);
                held = true;
                other.GetComponent<PlayerController>().HoldItem(this.gameObject);
                player = other.GetComponent<PlayerController>();
            }
        }
    }

    public void FixedUpdate()
    {
        if (held)
        {
            //transform.position = new Vector3(0, 0, 0);
            transform.localPosition = new Vector3(0, 0, 0);
        }
    }

    public void Use()
    {
        //Debug.Log("used item");
        held = false;
        col.enabled = true;
        //rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints.None;
        transform.SetParent(null);
        trigger.enabled = false;
        Invoke("EnableTrigger", 2);
        rb.AddForce(player.transform.forward * 1000, ForceMode.Force);

        if (attention != null)
        {
            attention.enabled = true;
            //Invoke("DisableAttention", 5);
        }

        if (threat != null)
        {
            threat.enabled = true;
            //Invoke("DisableAttention", 5);
        }

    }

    public void DisableAttention()
    {
        attention.enabled = false;
    }
    public void EnableTrigger()
    {
        trigger.enabled = true;
        
    }
}
