using UnityEngine;

public class Eve : Interactable
{
    [SerializeField] private string DialogueScript;

    protected override void Interaction()
    {
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this);
    }
}
