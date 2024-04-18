using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactable
{
    protected override void Interaction()
    {
        TimeManager.Instance.SkipTo(6);
        Debug.Log($"Hour: {TimeManager.Instance.Hour}");
    }
}
