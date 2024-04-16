using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBarrow : Interactable
{
    public override void InteractWith()
    {
        PlayerMain.Instance.WheelBarrow.Equip();
    }
}
