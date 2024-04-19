using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : Interactable
{
    protected override void Interaction()
    {
        PlayerMain.Instance.GetComponent<WateringCan>()._waterStorage = PlayerMain.Instance.GetComponent<WateringCan>().MaxWaterStorage;
    }
}
