using UnityEngine;

public class SellingSpot : Interactable
{
    [SerializeField] string DialogueScript;
    
    public int price = 10;

    public virtual void SellItem()
    {
        PlayerMain.Instance.Stats.AddMoney(-price);
    }

    protected override void Interaction()
    {
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this);
    }


}
