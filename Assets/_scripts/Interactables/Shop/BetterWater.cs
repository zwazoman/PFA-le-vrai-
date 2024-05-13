using UnityEngine;

public class BetterWater : SellingSpot
{
    [SerializeField] float _waterAddition;

    public override void SellItem()
    {
        base.SellItem();
        PlayerMain.Instance.Can.AddWaterToGive(_waterAddition);
    }
}
