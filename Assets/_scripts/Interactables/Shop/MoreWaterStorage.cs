using UnityEngine;

public class MoreWaterStorage : SellingSpot
{
    [SerializeField] int _waterStorageAddition;

    public override void SellItem()
    {
        base.SellItem();
        PlayerMain.Instance.Watering.MaxWaterStorage += _waterStorageAddition;
    }

}
