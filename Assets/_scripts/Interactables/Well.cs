using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : Interactable
{
    protected override void Interaction()
    {
        PlayerMain.Instance.Watering.Replenish();
    }
}
