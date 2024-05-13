using UnityEngine;

public class SellingSpot : Interactable
{
    [SerializeField] string DialogueScript;
    
    public int price = 10;
    private void Awake()
    {
        foreach(MonoBehaviour mb in GetComponents<MonoBehaviour>()) mb.enabled = false; //desactive l'item
    }

    public virtual void SellItem()
    {
        foreach (MonoBehaviour mb in GetComponents<MonoBehaviour>()) mb.enabled = true; //a l'item
        PlayerMain.Instance.Stats.AddMoney(-price);
    }

    protected override void Interaction()
    {
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this);
    }


}
