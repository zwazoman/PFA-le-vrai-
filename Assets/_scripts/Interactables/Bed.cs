using UnityEngine;

public class Bed : Interactable
{
    [SerializeField] private string DialogueScript;
    protected override void Interaction()
    {
        print("OwO");
       
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this); 
        print("XwX");
    }

    public void Sleep()
    {
        if (TimeManager.Instance.Hour < 6 || TimeManager.Instance.Hour > 20)
        {
            TimeManager.Instance.SkipTo(6);
            Debug.Log($"Hour: {TimeManager.Instance.Hour}");
        }
        else if (TimeManager.Instance.Hour > 6 && TimeManager.Instance.Hour < 20)
        {
            TimeManager.Instance.SkipTo(20);
            Debug.Log($"Hour: {TimeManager.Instance.Hour}");
        }
    }
}
