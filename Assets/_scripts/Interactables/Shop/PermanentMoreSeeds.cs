using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PermanentMoreSeeds : SellingSpot
{
    [SerializeField] int _seedsToAdd;

    private void Awake()
    {
        _stock = _maxStock;
    }
    public override void SellItem()
    {
        base.SellItem();
        PlayerMain.Instance.Stats.AddSeeds(_seedsToAdd);
    }
}
