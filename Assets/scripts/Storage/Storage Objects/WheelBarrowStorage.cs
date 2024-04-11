using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBarrowStorage : Storage
{
    [SerializeField] float _maxStorageWheelBarrow;

    protected override bool CanAbsorb(Item item)
    {
        return storageContent.Count <= _maxStorageWheelBarrow;
    }
    protected override void OnAbsorb(GameObject item)
    {
        //changer la bar de progression
    }
}
