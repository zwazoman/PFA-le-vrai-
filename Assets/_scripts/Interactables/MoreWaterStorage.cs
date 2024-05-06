using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreWaterStorage : Interactable
{
    [SerializeField] int _waterStorageAddition;

    protected override void Interaction()
    {
        PlayerMain.Instance.Watering.MaxWaterStorage += _waterStorageAddition;
        Destroy(gameObject);
        //a refaire dans la boite de dialogue
    }
}
