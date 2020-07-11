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

    public void DropItem()
    {
        if (!heldItem)
        {
            //use the item if holding one
        }
    }

    public void FixedUpdate()
    {
        
    }
}
