using DG.Tweening;
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

    private void Start()
    {
        if (CanRestock) TimeManager.Instance.OnDay += Restock;
    }

    public virtual void SellItem()
    {
        PlayerMain.Instance.Stats.AddMoney(-price);
        PlayerMain.Instance.Sounds.PlayBuySOund();
        Destock();
    }

    protected override void Interaction()
    {
        print(_stock);
        if(_stock == 0)
        {
            //dialogue hors stock
            print("hors stock");
            return;
        }
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this);
    }

    void Destock()
    {
        _stock -= 1;
        if (_stock == 0)
        {
            _itemShopVisual.enabled = false;
        }
    }

    public void Restock()
    {
        _itemShopVisual.enabled = true;
        _stock = _maxStock;
    }
}
