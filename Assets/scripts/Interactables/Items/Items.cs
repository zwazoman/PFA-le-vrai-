using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : Interactable
{
    public override void InteractWith()
    {
        PlayerMain.Instance.Hands.Pickup(gameObject);
    }
}
