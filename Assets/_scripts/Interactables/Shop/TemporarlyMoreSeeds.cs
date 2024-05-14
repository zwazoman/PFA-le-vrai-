using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporarilyMoreSeeds : SellingSpot
{
    [SerializeField] int _seedBoost;
    public override void SellItem()
    {
        base.SellItem();
        PlayerMain.Instance.Stats.TemporarlyAddSeeds(_seedBoost);
    }
}
