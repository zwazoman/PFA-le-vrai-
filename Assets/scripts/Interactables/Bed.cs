using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactable
{
    public override void InteractWith()
    {
        TimeManager.Instance.SkipTo(6);
        Debug.Log($"Hour: {TimeManager.Instance.Hour}");
    }
}
