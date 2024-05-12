using UnityEngine;

public class SellingSpot : Interactable
{
    [SerializeField] Item itemToSell;
    [SerializeField] string DialogueScript;
    
    public int price = 10;
    private void Awake()
    {
        foreach(MonoBehaviour mb in GetComponents<MonoBehaviour>()) mb.enabled = false; //desactive l'item
    }

    public void SellItem()
    {
        foreach (MonoBehaviour mb in GetComponents<MonoBehaviour>()) mb.enabled = true; //desactive l'item
        PlayerMain.Instance.Stats.AddMoney(-price);
        
        itemToSell.GetComponent<Item>().Jump();
        this.enabled = false;
    }

    protected override void Interaction()
    {
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this);
    }


}
