using UnityEngine;

public class Geoffrus : Interactable
{
    [SerializeField] private string DialogueScript;
    //[SerializeField] GameObject _key;

    protected override void Interaction()
    {
        _ = UiManager.Instance.PopupDialogue(DialogueScript, this);
    }

    public void GiveKey()
    {
        //Instantiate(_key);
        print("SUUUUUUUU(ce)");
    }
}