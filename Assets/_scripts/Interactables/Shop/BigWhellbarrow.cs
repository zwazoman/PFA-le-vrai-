using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWhellbarrow : SellingSpot
{
    [SerializeField] GameObject _whellbarrow;

    private void Awake()
    {
        _stock = _maxStock;
    }
    public override void SellItem()
    {
        base.SellItem();
        Instantiate(_whellbarrow);
    }
}
