using UnityEngine;

public class SellingSpot : Interactable
{
    [field: SerializeField]
    public bool CanRestock { get; private set; }

    [SerializeField] protected string DialogueScript;
    [SerializeField] protected MeshRenderer _itemShopVisual;
    [SerializeField] protected int _maxStock;

    protected int _stock;

    public int price = 10;

    public virtual void SellItem()
    {
        PlayerMain.Instance.Stats.AddMoney(-price);
    }

    protected override void Interaction()
    {
        if(_stock == 0)
        {
            //dialogue hors stock
            print("hors stock");
            return;
        }
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this);
    }


}
