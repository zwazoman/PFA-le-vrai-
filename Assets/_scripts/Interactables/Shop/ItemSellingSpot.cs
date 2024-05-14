using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSellingSpot : SellingSpot
{
    [SerializeField] Item itemToSell;

    public override void SellItem()
    {
        base.SellItem();
        SpawnItem();
    }

    private void SpawnItem()
    {
        itemToSell.GetComponent<Item>().Jump();
        this.enabled = false;
    }
}
