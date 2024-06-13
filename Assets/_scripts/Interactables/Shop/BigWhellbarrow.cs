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
        Instantiate(_whellbarrow,new Vector3(_transform.position.x + 2, _transform.position.y + 2, _transform.position.z + 2), Quaternion.identity) ;
    }
}
