using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform holdingPos;
    public GameObject heldItem;
    

    public bool HandsFull()
    {
        if (!heldItem)
            return false;
        else
            return true;
    }

    public void HoldItem(GameObject item)
    {
        if (heldItem == null)
        {
            heldItem = item;
        }
    }

    public void UseItem()
    {
        Debug.Log("got in use item");
        if (heldItem != null)
        {
            heldItem.GetComponent<PickupAble>().Use();
            //use the item if holding one
            heldItem = null;
        }
    }

    public void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (heldItem != null)
                UseItem();
        }
    }
}
