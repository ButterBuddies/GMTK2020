using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform holdingPos;
    public GameObject heldItem;
    public Transform lassoStartPoint;
    public LineRenderer lassoLine;
    public Transform lassoEndPoint;

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

    public void Lasso()
    {
        lassoLine.enabled = true;
        lassoLine.SetPosition(0, lassoStartPoint.position);
        lassoLine.SetPosition(1, lassoEndPoint.position);
    }

    public void HideLasso()
    {
        lassoLine.enabled = false;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem != null)
                UseItem();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            //if (heldItem != null)
            Lasso();
            Invoke("HideLasso", .5f);
        }
    }
}
