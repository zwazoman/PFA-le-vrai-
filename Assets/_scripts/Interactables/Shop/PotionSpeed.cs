using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionSpeed : Breakable
{
    protected override void Break()
    {
        base.Break();
        AddSpeed();

    }

    private void AddSpeed()
    {
        PlayerMain.Instance.Stats.WalkSpeed *= 1.3f;
        Debug.Log("Oui");
    }

}

