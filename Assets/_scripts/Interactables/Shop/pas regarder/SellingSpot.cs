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
        _effect.Play();
    }

    public virtual void SellItem()
    {
        PlayerMain.Instance.Stats.AddMoney(-price);
        PlayerMain.Instance.Sounds.PlayBuySound();
        Destock();
        if (_stock == 0) _effect.Stop();
    }

    protected override void Interaction()
    {
        if(_stock == 0)
        {
            //dialogue hors stock
            return;
        }
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this);
    }

    void Destock()
    {
        _stock -= 1;
        if (_stock == 0)
        {
            foreach(Transform child in _itemShopVisual.gameObject.transform)
            {
                if (child.gameObject.TryGetComponent<Renderer>(out Renderer renderer))
                {
                    renderer.enabled = false;   
                }
            }
            _itemShopVisual.enabled = false;
        }
    }

    public void Restock()
    {
        foreach (Transform child in _itemShopVisual.gameObject.transform)
        {
            if (child.gameObject.TryGetComponent<Renderer>(out Renderer renderer))
                {
                renderer.enabled = true;
            }
        }
        _itemShopVisual.enabled = true;
        _stock = _maxStock;
        _effect.Play();
    }
}
