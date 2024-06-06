using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BigWhellbarrow : SellingSpot
{
    [SerializeField] GameObject _whellbarrow;
    [SerializeField] Transform _transform;

    private void Awake()
    {
        _stock = _maxStock;
    }
    public override void SellItem()
    {
        base.SellItem();
        Instantiate(_whellbarrow, _transform.position, Quaternion.identity) ;
    }
}
