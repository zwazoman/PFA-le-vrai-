using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geoffrus : Interactable
{
    [SerializeField] private string DialogueScript;

    protected override void Interaction()
    {
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this);
    }
}