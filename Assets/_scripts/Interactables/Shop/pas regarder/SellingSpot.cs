using DG.Tweening;
using UnityEngine;
using UnityEngine.VFX;

public class SellingSpot : Interactable
{
    [field: SerializeField]
    public bool CanRestock { get; private set; }

    [SerializeField] protected string DialogueScript;
    [SerializeField] protected MeshRenderer _itemShopVisual;
    [SerializeField] protected int _maxStock;
    [SerializeField] protected VisualEffect _effect;

    protected int _stock;

    public int price = 10;

    private void Start()
    {
        if (CanRestock) TimeManager.Instance.OnDay += Restock;
    }

    public virtual void SellItem()
    {
        print("Putain Skyrim");
        PlayerMain.Instance.Stats.AddMoney(-price);
        PlayerMain.Instance.Sounds.PlayBuySound();
        Destock();
        _effect.Stop();
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
        _effect.Play();
    }
}
