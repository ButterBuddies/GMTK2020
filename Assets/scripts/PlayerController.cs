using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform holdingPos;
    public Transform lassoStartPoint;
    public LineRenderer lassoLine;
    public Transform lassoEndPoint;

    public Text Header;
    public Text Descript;
    public PickupAble heldItem;


    public bool tutorial = false;
    public int progress = 0;

    public bool UpdateUI()
    {
        // don't draw the text if I can't get the game object
        if (Header == null || Descript == null) return;
        // make sure we can pull the item off from teh gameobject.
        // if it's not null display text.
        Item item = heldItem?.item;
        if (item != null)
        {
            Header.text = item.Name;
            Descript.text = item.Descript;
        }
        // else set it empty.
        else
        {
            Header.text = string.Empty;
            Descript.text = string.Empty;
        }
    }

    public bool HandsFull()
    {
        return heldItem != null;
    }

    public void HoldItem(PickupAble item)
    {
        if (heldItem == null)
        {
            heldItem = item;
            UpdateUI();
        }
    }

    public void UseItem()
    {
        if (heldItem != null)
        {
            heldItem.GetComponent<PickupAble>().Use();
            //use the item if holding one
            heldItem = null;
            UpdateUI();
        }
        if (tutorial)
        {
            if (progress < 2)
            {
                progress++;
            }
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
