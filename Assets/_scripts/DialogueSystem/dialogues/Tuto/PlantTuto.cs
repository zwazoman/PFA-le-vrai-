using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantTuto : MonoBehaviour
{
    public static int Count = 0;
    [SerializeField] string _dialogueScript;

    public void ActivateTutorial()
    {
        print("OH LE TUTO");
        Count++;
        print(Count);
        if (Count == 3)
        {
            _ = UiManager.Instance.PopupDialogue(_dialogueScript, this);
        }
        Destroy(this);
    }
}
