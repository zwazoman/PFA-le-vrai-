using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MoreNextSeeds : Interactable
{
    [SerializeField] int _seedBoost;

    protected override void Interaction()
    {
        PlayerMain.Instance.Stats.TemporarlyAddSeeds(_seedBoost);
        Destroy(gameObject);
    }
}
