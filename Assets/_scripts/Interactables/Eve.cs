using UnityEngine;

public class Eve : Interactable
{
    [SerializeField] private string DialogueScript;

    protected override void Interaction()
    {
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this);
        QuestManager.Instance.TryProgressQuest("FindSoul", 1);
        QuestManager.Instance.TryProgressQuest("BuySoul", PlayerMain.Instance.Stats.Money);
    }
}
