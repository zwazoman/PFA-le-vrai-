using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBarrow : Item
{
    public override void InteractWith()
    {
        base.InteractWith();
        PlayerMain.Instance.HasWheelBarrow = true;
    }
}
